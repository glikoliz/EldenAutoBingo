using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using EldenBingo.Net;
using EldenBingoCommon;
using System.Text.Json;
using Neto.Shared;

namespace EldenBingo.AutoBingo
{
    public class BingoAutoChecker : IDisposable
    {
        private readonly System.Windows.Forms.Timer _checkTimer;
        private readonly Client _client;
        private readonly Dictionary<string, bool> _lastStates;
        private readonly ERMemoryReader _memoryReader;
        private readonly ERProcessMonitor _processMonitor;
        private bool _isDisposed;
        private bool _isRunning;
        private readonly Dictionary<string, MethodInfo> _squareMethods;

        public event EventHandler<AutoCheckEventArgs>? OnSquareChecked;
        public event EventHandler<string>? OnError;

        public bool IsRunning => _isRunning;

        public BingoAutoChecker(Client client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _lastStates = new Dictionary<string, bool>();
            _processMonitor = new ERProcessMonitor();
            _memoryReader = new ERMemoryReader(_processMonitor);

            _checkTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _checkTimer.Tick += CheckTimer_Tick;

            _processMonitor.ProcessChanged += ProcessMonitor_ProcessChanged;

            _squareMethods = BuildMethodMap();
        }

        private Dictionary<string, MethodInfo> BuildMethodMap()
        {
            var methods = typeof(AutoBingoSquares).GetMethods(BindingFlags.Public | BindingFlags.Static);
            var map = new Dictionary<string, MethodInfo>(StringComparer.OrdinalIgnoreCase);

            foreach (var method in methods)
            {
                var attr = method.GetCustomAttribute<AutoBingoSquares.BingoSquareAttribute>();
                if (attr != null)
                {
                    map[attr.SquareName] = method;
                }
            }
            return map;
        }

        private void ProcessMonitor_ProcessChanged(object? sender, EventArgs e)
        {
            if (!_processMonitor.IsProcessRunning)
            {
                OnError?.Invoke(this, "Elden Ring process not found");
                Stop();
            }
        }

        public void Start()
        {
            if (_isDisposed || _isRunning) return;

            _processMonitor.UpdateProcess(); // Force process check
            if (!_processMonitor.IsProcessRunning)
            {
                OnError?.Invoke(this, "Cannot start: Elden Ring process not found");
                return;
            }
            ValidateSquares();

            _isRunning = true;
            _checkTimer.Start();
            Debug.WriteLine("AutoChecker started");

        }

        public void Stop()
        {
            if (_isDisposed || !_isRunning) return;
            _isRunning = false;
            _checkTimer.Stop();
            _lastStates.Clear();
            Debug.WriteLine("AutoChecker stopped");
        }

        private async void CheckTimer_Tick(object? sender, EventArgs e)
        {
            if (!_processMonitor.IsProcessRunning)
            {
                Stop();

                OnError?.Invoke(this, "Lost connection to Elden Ring process");
                return;
            }

            if (_client.BingoBoard == null || _client.Room?.Match?.MatchStatus != MatchStatus.Running) return;

            var uncheckedSquares = _client.BingoBoard.Squares.Where(square => !square.Checked);

            foreach (var square in uncheckedSquares)
            {
                if (_squareMethods.TryGetValue(square.Text, out var methodInfo))
                {
                    try
                    {
                        bool result = (bool)methodInfo.Invoke(null, null)!;
                        if (!_lastStates.ContainsKey(methodInfo.Name) || _lastStates[methodInfo.Name] != result)
                        {
                            _lastStates[methodInfo.Name] = result;
                            if (result && _client.LocalUser != null)
                            {
                                var checkPacket = new Packet(new ClientTryCheck(
                                    Array.IndexOf(_client.BingoBoard.Squares, square),
                                    _client.LocalUser.Guid));
                                await _client.SendPacketToServer(checkPacket);
                                OnSquareChecked?.Invoke(this, new AutoCheckEventArgs(square.Text, true));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error checking {methodInfo.Name}: {ex.Message}");
                    }
                }
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Stop();
                _checkTimer.Dispose();
                _processMonitor.ProcessChanged -= ProcessMonitor_ProcessChanged;
                _processMonitor.Dispose();
                _isDisposed = true;
            }
            GC.SuppressFinalize(this);
        }

        private class BingoSquareInfo
        {
            public string name { get; set; } = "";
            public string func_name { get; set; } = "";
        }

        public class AutoCheckEventArgs : EventArgs
        {
            public string SquareText { get; }
            public bool Completed { get; }

            public AutoCheckEventArgs(string squareText, bool completed)
            {
                SquareText = squareText;
                Completed = completed;
            }
        }

        private void ValidateSquares()
        {
            if (_client.BingoBoard == null) return;

            var implementedSquares = _squareMethods.Keys.ToHashSet(StringComparer.OrdinalIgnoreCase);
            var bingoSquares = _client.BingoBoard.Squares.Select(s => s.Text);
            
            var missingSquares = bingoSquares.Where(square => !implementedSquares.Contains(square)).ToList();

            if (missingSquares.Any())
            {
                var errorMessage = $"WARNING: {missingSquares.Count} bingo squares are not implemented:\n" +
                    string.Join("\n", missingSquares.Select(s => $"- {s}"));
                Debug.WriteLine(errorMessage);
                OnError?.Invoke(this, errorMessage);
            }
        }
    }
}