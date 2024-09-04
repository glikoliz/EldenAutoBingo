using Microsoft.VisualBasic;
using System;
using System.Diagnostics;

namespace Elden_Ring_Auto_Bingo
{
    public class ERConstants
    {
        private ERMemoryReader er;

        public ERConstants(ERMemoryReader er)
        {
            this.er = er;
        }

        public long GetWorldchrman()
        {
            byte[] pattern = new byte[]
            {
                0x48, 0x8B, 0x05,
                0x00, 0x00, 0x00, 0x00,
                0x48, 0x85, 0xC0, 0x74, 0x0F, 0x48, 0x39, 0x88
            };
            long addr = er.FindPatternInModule(er.ERProcess.MainModule, pattern);
            return addr + er.ReadInt(addr + 3) + 7;
        }
        public long GetEventflagman()
        {
            byte[] pattern = new byte[]
            {
                0x48, 0x8B, 0x3D,
                0x00, 0x00, 0x00, 0x00,
                0x48, 0x85, 0xFF, 0x00, 0x00, 0x32, 0xC0, 0xE9
            };
            long addr = er.FindPatternInModule(er.ERProcess.MainModule, pattern);
            return addr + er.ReadInt(addr + 3) + 7;
        }
        public int GetChrcount()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            long begin = er.ReadLong(worldchrman + 0x1F1B8);
            long end = er.ReadLong(worldchrman + 0x1F1C0);
            int chr_count = (int)(end - begin) / 8;
            return chr_count;
        }
        public long GetChrset()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            long chrset = er.ReadLong(worldchrman + 0x1F1B8);
            return chrset;
        }
        public long FindAddrById(long enemyid)
        {
            int chr_count = GetChrcount();
            long enemyaddr = 0;
            long chrset = GetChrset();
            for (int i = 0; i < chr_count; i++)
            {
                enemyaddr = er.ReadLong(chrset + i * 0x10);
                int paramid = er.ReadInt(enemyaddr + 0x60);
                if (paramid == enemyid)
                {
                    Console.WriteLine(enemyaddr.ToString("x8"));
                    return enemyaddr;
                }
            }
            return 0;
        }
    }
}
