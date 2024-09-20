namespace Elden_Ring_Auto_Bingo
{
    public class ERConstants
    {
        private readonly ERMemoryReader er;
        private long? cachedWorldchrman;
        private long? cachedEventflagman;

        public ERConstants(ERMemoryReader er)
        {
            this.er = er;
            er.ProcessChanged += OnProcessChanged;
            
        }

        private void OnProcessChanged(object? sender, EventArgs e)
        {
            ResetCache();
        }

        public void ResetCache()
        {
            cachedWorldchrman = null;
            cachedEventflagman = null;
        }

        public long GetWorldchrman()
        {
            if (!er.IsValid || !cachedWorldchrman.HasValue)
            {
                byte[] pattern = new byte[]
                {
                    0x48, 0x8B, 0x05,
                    0x00, 0x00, 0x00, 0x00,
                    0x48, 0x85, 0xC0, 0x74, 0x0F, 0x48, 0x39, 0x88
                };
                if (er.ERProcess?.MainModule == null)
                    return 0;
                long addr = er.FindPatternInModule(er.ERProcess.MainModule, pattern);
                cachedWorldchrman = addr + er.ReadInt(addr + 3) + 7;
            }
            return cachedWorldchrman ?? 0;
        }

        public long GetEventflagman()
        {
            if (!er.IsValid || !cachedEventflagman.HasValue)
            {
                byte[] pattern = new byte[]
                {
                    0x48, 0x8B, 0x3D,
                    0x00, 0x00, 0x00, 0x00,
                    0x48, 0x85, 0xFF, 0x00, 0x00, 0x32, 0xC0, 0xE9
                };
                if (er.ERProcess?.MainModule == null)
                    return 0;
                long addr = er.FindPatternInModule(er.ERProcess.MainModule, pattern);
                cachedEventflagman = addr + er.ReadInt(addr + 3) + 7;
            }
            return cachedEventflagman ?? 0;
        }

        public int GetChrCount()
        {
            if (!er.IsValid) return 0;
            long worldchrman = er.ReadLong(GetWorldchrman());
            long begin = er.ReadLong(worldchrman + 0x1F1B8);
            long end = er.ReadLong(worldchrman + 0x1F1C0);
            return (int)(end - begin) / 8;
        }

        public long GetChrSet()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            return er.ReadLong(worldchrman + 0x1F1B8);
        }

        public long GetPlayerAnim()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            return er.GetOffsets(worldchrman, [0x10EF8, 0, 0x58, 0x10, 0x190, 0x18, 0x40]);
        }

        public long GetPlayerDamageRate()
        {
            long worldchrman = er.ReadLong(GetWorldchrman());
            return er.GetOffsets(worldchrman, [0x10EF8, 0, 0x190, 0x98, 0x44]);
        }

        public long GetCurrentBoss()
        {
            if (er.ERProcess?.MainModule == null)
                throw new InvalidOperationException("MainModule is null");
            return er.GetOffsets(er.ERProcess.MainModule.BaseAddress, [0x03B40820, 0x244]);
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
            if (er.ERProcess?.MainModule == null)
                throw new InvalidOperationException("MainModule is null");
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
                    return true;
            }
            return false;
        }

        public long FindAddrById(long enemyid)
        {
            int chr_count = GetChrCount();
            long chrset = GetChrSet();
            for (int i = 0; i < chr_count; i++)
            {
                long enemyaddr = er.ReadLong(chrset + i * 8);
                int paramid = er.ReadInt(enemyaddr + 0x60);
                if (paramid == enemyid)
                    return enemyaddr;
            }
            return 0;
        }

        public enum BossId
        {
            Margit = 21300014,
            Morgott = 21300534,
            Rykard1 = 47100038,
            Rykard2 = 47101038,
            Godrick = 47500014,
            Radahn = 47300040,
            Renalla = 20310024,
            RealMohg = 48000068,
            Melania = 21200056,
            RegalSpirit = 46700065,
            Astel = 46200062,
            Fortissax = 45110066,
            Placidusax = 45200072,
            FireGiant1 = 47600050,
            FireGiant2 = 47601050,
            Maliketh1 = 21100072,
            Maliketh2 = 21101072,
            Godfrey = 47200134,
            EldenBeast = 22000078,
            GodskinNobleVolcano = 35700038,
            Mimic = 526100965,
            SoldierOfGod = 43113906,
            LimgraveTreeSentinel = 32510010,
            Agheel = 45000010,
            Nepheli = 533340014
        }

        public static readonly int[] REMEMBRANCE_BOSSES_PARAM_ID = {
            (int)BossId.Godrick, (int)BossId.Renalla, (int)BossId.Radahn, (int)BossId.Morgott,
            (int)BossId.Rykard1, (int)BossId.Rykard2, (int)BossId.RealMohg, (int)BossId.Melania,
            (int)BossId.RegalSpirit, (int)BossId.Astel, (int)BossId.Fortissax, (int)BossId.Placidusax,
            (int)BossId.FireGiant1, (int)BossId.FireGiant2, (int)BossId.Maliketh1, (int)BossId.Maliketh2,
            (int)BossId.Godfrey, (int)BossId.EldenBeast
        };

        public const int MARGIT_PARRY_ANIM1 = 2008500;
        public const int MARGIT_PARRY_ANIM2 = 2020015;
    }
}
