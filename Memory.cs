using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Elden_Ring_Auto_Bingo
{
    public class CMem
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

        public static IntPtr GetProcess(int id)
        {
            return OpenProcess(ProcessAccessFlags.All, false, id);
        }
        public static byte[] ReadBytes(IntPtr process, long address, uint size)
        {
            byte[] buffer = new byte[size];
            int bytesRead = 0;
            ReadProcessMemory(process, address, buffer, size, out bytesRead);
            return buffer;
        }
        public static int ReadInt(IntPtr process, long address)
        {
            byte[] buffer = new byte[sizeof(int)];
            int bytesRead = 0;
            ReadProcessMemory(process, address, buffer, sizeof(int), out bytesRead);
            int value = BitConverter.ToInt32(buffer, 0);
            return value;
        }
        public static long ReadLongLong(IntPtr process, long address)
        {
            byte[] buffer = new byte[sizeof(long)];
            int bytesRead = 0;
            ReadProcessMemory(process, address, buffer, sizeof(long), out bytesRead);
            long value = BitConverter.ToInt64(buffer, 0);
            return value;
        }
        public static float ReadFloat(IntPtr process, long address)
        {
            byte[] buffer = new byte[sizeof(float)];
            int bytesRead = 0;
            ReadProcessMemory(process, address, buffer, sizeof(float), out bytesRead);
            float value = BitConverter.ToSingle(buffer, 0);
            return value;
        }
        public static long GetOffsets(IntPtr process, long address, int[] offsets)
        {
            long result = address;

            for (int i = 0; i < offsets.Length - 1; i++)
            {
                result = ReadLongLong(process, result + offsets[i]);
            }
            return result + offsets[offsets.Length - 1];
        }
        public static long FindPatternInModule(IntPtr process, ProcessModule module, byte[] pattern)
        {
            long moduleBase = module.BaseAddress.ToInt64();
            uint moduleSize = (uint)module.ModuleMemorySize;

            byte[] moduleBytes = ReadBytes(process, moduleBase, moduleSize);

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
    }
}