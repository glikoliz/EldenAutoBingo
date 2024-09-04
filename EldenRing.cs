using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Elden_Ring_Auto_Bingo
{
    public class ERMemoryReader
    {
        [Flags]
        public enum ProcessAccessFlags : int
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
        private long baseAddress;
        private Process erProcess;

        public ERMemoryReader()
        {
            erProcess = Process.GetProcessesByName("eldenring")[0];
            processHandle = OpenProcess(ProcessAccessFlags.All, false, erProcess.Id);
            baseAddress = erProcess.MainModule.BaseAddress.ToInt64();
        }

        public Process ERProcess
        {
            get { return erProcess; }
        }

        public byte[] ReadBytes(long address, uint size)
        {
            byte[] buffer = new byte[size];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, size, out bytesRead);
            
            return buffer;
        }

        public byte ReadByte(long address)
        {
            byte[] buffer = new byte[1];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, 1, out bytesRead);

            return buffer[0];
        }

        public int ReadInt(long address)
        {
            byte[] buffer = new byte[sizeof(int)];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, sizeof(int), out bytesRead);
            return BitConverter.ToInt32(buffer, 0);
        }

        public long ReadLong(long address)
        {
            byte[] buffer = new byte[sizeof(long)];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, sizeof(long), out bytesRead);
            return BitConverter.ToInt64(buffer, 0);
        }

        public float ReadFloat(long address)
        {
            byte[] buffer = new byte[sizeof(float)];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, address, buffer, sizeof(float), out bytesRead);
            return BitConverter.ToSingle(buffer, 0);
        }

        public long GetOffsets(long address, int[] offsets)
        {
            long result = address;

            for (int i = 0; i < offsets.Length - 1; i++)
            {
                result = ReadLong(result + offsets[i]);
            }
            return result + offsets[offsets.Length - 1];
        }

        public long FindPatternInModule(ProcessModule module, byte[] pattern)
        {
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
            CloseHandle(processHandle);
        }
    }
}
