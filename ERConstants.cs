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
        public long GetPlayerDamageRate()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            long addr = er.GetOffsets(worldchrman, [0x10EF8, 0, 0x190, 0x98, 0x44]);
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
        public int GetEnemyHP(long enemyaddr)
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
        public int GetCurrentWeaponId()
        {
            long addr = er.GetOffsets(er.ReadLong(er.ERProcess.MainModule.BaseAddress + 0x03B12E30), [0x0, 0x58, 0x18, 0x108, 0x0, 0xA8, 0x1F0]);
            return er.ReadInt(addr);
        }
        public bool FindExplosiveFlaskEffect()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            long addr = er.ReadLong(worldchrman + 0x10EF8);
            addr = er.ReadLong(addr);
            addr = er.ReadLong(addr + 0x178);
            addr = er.ReadLong(addr + 0x8);
            for (int i = 0; i < 15; i++)
            {
                addr = er.ReadLong(addr + 0x30);
                if (addr == 0)
                    break;
                //Console.WriteLine((addr+8).ToString("X8"));
                int effect = er.ReadInt(addr + 8);
                if (effect == 511074 || effect == 511075 || effect == 511080)
                    return true;
            }
            return false;
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
        public const int MORGOTT_PARAM_ID = 21300534;
        public const int RYKARD_PARAM_ID1 = 47100038;
        public const int RYKARD_PARAM_ID2 = 47101038;
        public const int GODRICK_PARAM_ID = 47500014;
        public const int RADAHN_PARAM_ID = 47300040;
        public const int RENALLA_PARAM_ID = 20310024;
        public const int REAL_MOHG_PARAM_ID = 48000068;
        public const int MELANIA_PARAM_ID = 21200056;
        public const int REGAL_SPIRIT_PARAM_ID = 46700065;
        public const int ASTEL_PARAM_ID = 46200062;
        public const int FORTISSAX_PARAM_ID = 45110066;
        public const int PLACIDUSAX_PARAM_ID = 45200072;
        public const int FIRE_GIANT_PARAM_ID1 = 47600050;
        public const int FIRE_GIANT_PARAM_ID2 = 47601050;
        public const int MALIKETH_PARAM_ID1 = 21100072;
        public const int MALIKETH_PARAM_ID2 = 21101072;
        public const int GODFREY_PARAM_ID = 47200134;
        public const int ELDEN_BEAST_PARAM_ID = 22000078;

        public const int GODSKIN_NOBLE_VOLCANO_PARAM_ID = 35700038;
        public const int MIMIC_PARAM_ID = 526100965;
        public const int SOLDIER_OF_GOD_PARAM_ID = 43113906;
        public const int LIMGRAVE_TREE_SENTINTEL_PARAM_ID = 32510010;
        public const int AGHEEL_PARAM_ID = 45000010;
        public static int[] REMEMBRANCE_BOSSES_PARAM_ID = { GODRICK_PARAM_ID, RENALLA_PARAM_ID, RADAHN_PARAM_ID, MORGOTT_PARAM_ID, 
            RYKARD_PARAM_ID1, RYKARD_PARAM_ID2, REAL_MOHG_PARAM_ID, MELANIA_PARAM_ID, REGAL_SPIRIT_PARAM_ID, ASTEL_PARAM_ID, FORTISSAX_PARAM_ID, 
            PLACIDUSAX_PARAM_ID, FIRE_GIANT_PARAM_ID1, FIRE_GIANT_PARAM_ID2, MALIKETH_PARAM_ID1,MALIKETH_PARAM_ID2, GODFREY_PARAM_ID, ELDEN_BEAST_PARAM_ID};

        public const int NEPHELI_PARAM_ID = 533340014;

        public const int MARGIT_PARRY_ANIM1 = 2008500;
        public const int MARGIT_PARRY_ANIM2 = 2020015;



    }
}
