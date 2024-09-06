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
        public int GetChrCount()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            long begin = er.ReadLong(worldchrman + 0x1F1B8);
            long end = er.ReadLong(worldchrman + 0x1F1C0);
            int chr_count = (int)(end - begin) / 8;
            return chr_count;
        }
        public long GetChrSet()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            long chrset = er.ReadLong(worldchrman + 0x1F1B8);
            return chrset;
        }
        public long GetPlayerAnim()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            long addr = er.GetOffsets(worldchrman, [0x10EF8, 0, 0x58, 0x10, 0x190, 0x18, 0x40]);
            return addr;
        }
        public long GetCurrentBoss()
        {
            return er.GetOffsets(er.ERProcess.MainModule.BaseAddress, [0x03D5DF58, 0xCC]);
        }
        public long GetEnemyResistances(long enemyaddr)
        {
            return er.GetOffsets(enemyaddr, [0x190, 0x20, 0x10]);
        }
        public long GetEnemyHP(long enemyaddr)
        {
            return er.ReadInt(er.GetOffsets(enemyaddr, [0x190, 0, 0x138]));
        }
        public int GetEnemyCurrentAnim(long enemyaddr)
        {
            return er.ReadInt(er.GetOffsets(enemyaddr, [0x190, 0x18, 0x40]));
        }
        public byte GetNpcAlliance(long addr)
        {
            return er.ReadByte(er.GetOffsets(addr, [0x6C]));
        }
        public long IsBossDeadAddr(long bossaddr)
        {
            return er.GetOffsets(bossaddr, [0x58, 0xC8, 0x24]);

        }
        public bool IsStatusEffectUsed(long boss_id)
        {
            long resistance = GetEnemyResistances(boss_id);
            for (long addr = resistance; addr < resistance + 7 * 4; addr += 4)
            {
                long currentResistance = er.ReadInt(addr);
                long maxResistance = er.ReadInt(addr + 0x1C);
                if (currentResistance != maxResistance)
                {
                    return true;
                }
            }
            return false;
        }
        public long FindAddrById(long enemyid)
        {
            int chr_count = GetChrCount();
            long enemyaddr = 0;
            long chrset = GetChrSet();
            for (int i = 0; i < chr_count; i++)
            {
                enemyaddr = er.ReadLong(chrset + i * 8);
                int paramid = er.ReadInt(enemyaddr + 0x60);
                if (paramid == enemyid)
                {
                    return enemyaddr;
                }
            }
            return 0;
        }

        public const int MARGIT_PARAM_ID = 21300014;
        public const int GODRICK_PARAM_ID = 47500014;
        public const int GODSKIN_NOBLE_VOLCANO_PARAM_ID = 35700038;
        public const int RENALLA_PARAM_ID = 20310024;
        public const int RADAHN_PARAM_ID = 47300040;



        public const int NEPHELI_PARAM_ID = 533340014;

        public const int MARGIT_PARRY_ANIM1 = 2008500;
        public const int MARGIT_PARRY_ANIM2 = 2020015;



    }
}
