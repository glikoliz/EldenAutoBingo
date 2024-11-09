using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenBingo.AutoBingo
{
    public class ERProcessMonitor : IDisposable
    {
        private const string ProcessName = "eldenring";
        private Process? _currentProcess;
        private readonly System.Windows.Forms.Timer _processCheckTimer;
        public event EventHandler? ProcessChanged;

        public ERProcessMonitor()
        {
            _processCheckTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _processCheckTimer.Tick += CheckProcess;
            _processCheckTimer.Start();
            UpdateProcess(); // Initial check
        }

        public Process? CurrentProcess => _currentProcess?.HasExited == false ? _currentProcess : null;
        public bool IsProcessRunning => CurrentProcess != null;

        private void CheckProcess(object? sender, EventArgs e)
        {
            var wasRunning = IsProcessRunning;
            UpdateProcess();
            if (wasRunning != IsProcessRunning)
            {
                ProcessChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void UpdateProcess()
        {
            if (_currentProcess?.HasExited == true)
            {
                _currentProcess.Dispose();
                _currentProcess = null;
            }

            if (_currentProcess == null)
            {
                var processes = Process.GetProcessesByName(ProcessName);
                _currentProcess = processes.Length > 0 ? processes[0] : null;
            }
        }

        public void Dispose()
        {
            _processCheckTimer.Stop();
            _processCheckTimer.Dispose();
            if (_currentProcess != null)
            {
                _currentProcess.Dispose();
                _currentProcess = null;
            }
        }
    }
}
