using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenBingo.AutoBingo
{
    internal class ERConstants
    {
        private readonly ERMemoryReader er;
        private long? cachedWorldChrMan;
        private long? cachedEventFlagMan;
        private long? cachedGameDataMan;


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
            cachedWorldChrMan = null;
            cachedEventFlagMan = null;
            cachedGameDataMan = null;

        }

        public long GetWorldchrman()
        {
            if (!er.IsValid || !cachedWorldChrMan.HasValue)
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
                cachedWorldChrMan = addr + er.ReadInt(addr + 3) + 7;
            }
            return cachedWorldChrMan ?? 0;
        }

        public long GetEventFlagMan()
        {
            if (!er.IsValid || !cachedEventFlagMan.HasValue)
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
                cachedEventFlagMan = addr + er.ReadInt(addr + 3) + 7;
            }
            return cachedEventFlagMan ?? 0;
        }
        public long GetGameDataMan()
        {
            if (!er.IsValid || !cachedGameDataMan.HasValue)
            {
                byte[] pattern = new byte[]
                {
                    0x48, 0x8B, 0x05,
                    0x00, 0x00, 0x00, 0x00,
                    0x48, 0x85, 0xC0, 0x74, 0x05, 0x48, 0x8B, 0x40, 0x58, 0xC3, 0xC3
                };
                if (er.ERProcess?.MainModule == null)
                    return 0;
                long addr = er.FindPatternInModule(er.ERProcess.MainModule, pattern);
                cachedGameDataMan = addr + er.ReadInt(addr + 3) + 7;
            }
            return cachedGameDataMan ?? 0;
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
                return 0;
            return er.GetOffsets((long)er.ERProcess.MainModule.BaseAddress, [0x03B40820, 0x244]);
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
                return 0;
            long addr = er.GetOffsets(er.ReadLong((long)er.ERProcess.MainModule.BaseAddress + 0x03B12E30), [0x0, 0x58, 0x18, 0x108, 0x0, 0xA8, 0x1F0]);
            return er.ReadInt(addr);
        }
        public int GetCurrentTransformation()
        {
            if (er.ERProcess?.MainModule == null)
                return 0;
            long addr = er.GetOffsets(er.ReadLong((long)er.ERProcess.MainModule.BaseAddress + 0x03D6B7B0), [0x10, 0x94]);
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
            Bayle = 51200085,
            Lion = 52100088,
            Rellana = 53000082,
            Messmer1 = 51300099,
            Messmer2 = 51301099,
            Gay = 50000092,
            Sunflower1 = 52300196,
            Sunflower2 = 52300496,
            Sunflower3 = 52300596,

        }
        //52300196 52300496 52300596
        public static readonly int[] REMEMBRANCE_BOSSES_PARAM_ID = {
            (int)BossId.Bayle, (int)BossId.Lion, (int)BossId.Rellana, (int)BossId.Messmer1, (int)BossId.Messmer2, (int)BossId.Gay, (int)BossId.Sunflower1, (int)BossId.Sunflower2, (int)BossId.Sunflower3,
        };

        public bool CheckFlag(int offset, int bitPosition)
        {
            long eventFlag = er.ReadLong(GetEventFlagMan());
            long boss = er.GetOffsets(eventFlag, [0x28, offset]);
            return (er.ReadByte(boss) & (1 << bitPosition)) != 0;
        }

        public int CountFlags((int Boss, int Byte)[] bossesData)
        {
            return CountFlags(bossesData.Select(x => (x.Boss, x.Byte, 1)).ToArray());
        }

        public int CountFlags((int Boss, int Byte, int Count)[] bossesData)
        {
            long eventFlag = er.ReadLong(GetEventFlagMan());
            int count = 0;
            long boss;
            foreach (var (offset, bitPosition, enemyCount) in bossesData)
            {
                boss = er.GetOffsets(eventFlag, [0x28, offset]);
                if ((er.ReadByte(boss) & (1 << bitPosition)) != 0)
                    count += enemyCount;
            }
            return count;
        }

    }
}
