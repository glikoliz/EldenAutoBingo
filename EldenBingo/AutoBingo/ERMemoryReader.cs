using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EldenBingo.AutoBingo
{
    internal class ERMemoryReader
    {
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF
        }

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        private IntPtr processHandle;
        private ERProcessMonitor processMonitor;

        public event EventHandler? ProcessChanged;

        public ERMemoryReader(ERProcessMonitor monitor)
        {
            processMonitor = monitor;
            processMonitor.ProcessChanged += OnProcessChanged;
            UpdateProcessHandle();
            processMonitor.UpdateProcess();
        }

        private void OnProcessChanged(object? sender, EventArgs e)
        {
            UpdateProcessHandle();
            ProcessChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateProcessHandle()
        {

            if (processHandle != IntPtr.Zero)
                CloseHandle(processHandle);
            if (processMonitor.CurrentProcess != null)
                processHandle = OpenProcess(ProcessAccessFlags.All, false, processMonitor.CurrentProcess.Id);
            else
                processHandle = IntPtr.Zero;
        }

        public bool IsValid => processHandle != IntPtr.Zero;

        public Process? ERProcess => processMonitor.CurrentProcess;

        public byte[] ReadBytes(long address, uint size)
        {
            if (!IsValid) return Array.Empty<byte>();

            byte[] buffer = new byte[size];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, size, out bytesRead);

            return buffer;
        }

        public byte ReadByte(long address)
        {
            if (!IsValid) return 0;

            byte[] buffer = new byte[1];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, 1, out bytesRead);

            return buffer[0];
        }

        public int ReadInt(long address)
        {
            if (!IsValid) return 0;

            byte[] buffer = new byte[sizeof(int)];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, sizeof(int), out bytesRead);
            return BitConverter.ToInt32(buffer, 0);
        }

        public long ReadLong(long address)
        {
            if (!IsValid) return 0;

            byte[] buffer = new byte[sizeof(long)];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, sizeof(long), out bytesRead);
            return BitConverter.ToInt64(buffer, 0);
        }

        public float ReadFloat(long address)
        {
            if (!IsValid) return 0;

            byte[] buffer = new byte[sizeof(float)];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, sizeof(float), out bytesRead);
            return BitConverter.ToSingle(buffer, 0);
        }

        public long GetOffsets(long address, int[] offsets)
        {
            if (!IsValid) return 0;

            long result = address;

            for (int i = 0; i < offsets.Length - 1; i++)
            {
                result = ReadLong(result + offsets[i]);
                if (result == 0) return 0;
            }
            return result + offsets[offsets.Length - 1];
        }

        public long FindPatternInModule(ProcessModule module, byte[] pattern)
        {
            if (!IsValid) return 0;

            long moduleBase = module.BaseAddress.ToInt64();
            uint moduleSize = (uint)module.ModuleMemorySize;

            byte[] moduleBytes = ReadBytes(moduleBase, moduleSize);

            for (long i = 0; i < moduleSize - pattern.Length; i++)
            {
                bool found = true;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] != 0x00 && moduleBytes[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return moduleBase + i;
                }
            }

            return 0;
        }

        ~ERMemoryReader()
        {
            if (processHandle != IntPtr.Zero)
            {
                CloseHandle(processHandle);
            }
        }
    }
}
