namespace Elden_Ring_Auto_Bingo
{
    public static class BingoSquares
    {
        private static ERMemoryReader er = new ERMemoryReader(new ERProcessMonitor());
        private static ERConstants constants = new ERConstants(er);
        private static long eventFlag = er.ReadLong(constants.GetEventflagman());

        private static bool IsBossDead(int[] offsets, int bitPosition)
        {
            foreach (var offset in offsets)
            {
                long boss = er.GetOffsets(eventFlag, [0x28, offset]);
                if ((er.ReadByte(boss) & (1 << bitPosition)) != 0)
                    return true;
            }
            return false;
        }
        private static int KilledBossesCount((int Boss, int Byte, int Count)[] bossesData)
        {
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
        public static bool LeonineDead() => IsBossDead([0xA7B7F], 7);
        public static bool GoldenHippoDead() => IsBossDead([0x477], 7);
        public static bool MidraDead() => IsBossDead([0x90], 3);
        public static bool RadahnDead() => IsBossDead([0x8E], 0);
        public static bool DancingLionDead() => IsBossDead([0x8E], 3) || IsBossDead([0x174F3], 7);
        public static bool AncientSenessaxDead() => IsBossDead([0x2DCD], 2);
        public static bool BlackKnightDead() => IsBossDead([0x2DE1], 2) || IsBossDead([0x2DE0], 4);
        public static bool JoriDead() => IsBossDead([0x91], 6);
        public static bool LamenterDead() => IsBossDead([0x9F], 2);
        public static bool DeathKnightDead() => IsBossDead([0x9E], 1) || IsBossDead([0x9E], 0);
        public static bool MariggaDead() => IsBossDead([0x2DD2], 2);
        public static bool BloodfiendDead() => IsBossDead([0xA0], 7);
        public static bool PutrescentKnightDead() => IsBossDead([0x8F], 3);
        public static bool DryleafDaneDead() => IsBossDead([0x25689], 7); //test this
        public static bool ScadutreeAvatarDead() => IsBossDead([0x91], 5);
        public static bool RellanaDead() => IsBossDead([0x47C], 1);
        public static bool MetyrDead() => IsBossDead([0x478], 4);
        public static bool MessmerDead() => IsBossDead([0x477], 5);
        public static bool SentinelDuoDead() => IsBossDead([0x2DDF], 1);
        public static bool RominaDead() => IsBossDead([0x91], 7);
        public static bool DragonManDead() => IsBossDead([0xA0], 6);
        public static bool DeathRiteBirdDead() => IsBossDead([0x1ABA3], 7);
        public static bool RedBearDead() => IsBossDead([0x2DD9], 3);
        public static bool FrenzyNPCDead() => IsBossDead([0x3310A], 3);

        public static bool RemembranceBossesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x8E, 3, 1), //Dancing lion
                (0x47C, 1, 1), //Rellana
                (0x8F, 3, 1), //Putrescent
                (0x91, 3, 1), //Gaius
                (0x91, 4, 1), //Bayle
                (0x91, 5, 1), // Avatar
                (0x91, 7, 1), //Romina
                (0x90, 3, 1), //Midra
                (0x478, 4, 1), //Metyr
                (0x477, 5, 1), //Messmmer
                (0x8E, 0, 1), //Radahn
            };
            return KilledBossesCount(bossesData) >= 4;
        }
        public static bool NpcBossesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x2DD0, 1, 1), //Rakhasa
                (0x2DD9, 3, 1), //Red bear
                (0x16459, 7, 1), //Lonely man
                (0x15A18, 3, 1), //Dancer
                (0x25689, 7, 1), //Dryleaf Dane(test this)
                (0x9F, 2, 1), //Lamenter
            }; //Leda fight isn't a boss fight
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool DragonBossesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x2DD4, 3, 1), //Gravesite ghostflame dragon
                (0x25431, 3, 1), //Cerulean ghostflame dragon
                (0x2531E, 7, 1), //scadu ghostflame
                (0x489, 5, 1), //Jagged drake peak
                (0x2DCD, 2, 1), //Sennessax
                (0x91, 4, 1), //Bayle
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool BaseGameBossesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x2DD2, 2, 1), //Marigga
                (0x2DDF, 1, 1), //Tree sentinel 1
                (0x2AC7B, 1, 1), //Tree sentinel 2
                (0x2DE1, 7, 1), //fallingstar beast
                (0x1ABA3, 7, 1), //Deathrite bird
                (0x2DCD, 2, 1), //Sennessax
            };
            return KilledBossesCount(bossesData) >= 1;
        }
        public static bool FurnaceGolemsDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x2A853, 1, 1),
                (0x2A852, 3, 1),
            };//TODO
            return KilledBossesCount(bossesData) >= 5;
        }
    }
}