namespace Elden_Ring_Auto_Bingo
{
    public static class BingoSquares
    {
        private static ERMemoryReader er;
        private static ERConstants constants;

        static BingoSquares()
        {
            er = new ERMemoryReader();
            constants = new ERConstants(er);
        }

        public static bool IsLeonineDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xA7B7F]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }

        public static bool IsRedWolfDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x15814C]);
            bool flag = (er.ReadByte(boss) & (1 << 5)) != 0;
            return flag;
        }

        public static bool IsGodskinApostleDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstApostle = er.GetOffsets(eventflag, [0x28, 0xA483A]);
            long secondApostle = er.GetOffsets(eventflag, [0x28, 0x16310E]);
            bool flag = ((er.ReadByte(firstApostle) & (1 << 7)) != 0) || 
                ((er.ReadByte(secondApostle) & (1 << 7)) != 0);
            return flag;
        }
        public static bool IsGoldenGodfreyDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x152DCD]);
            bool flag = (er.ReadByte(boss) & (1 << 5)) != 0;
            return flag;
        }
        public static bool IsFiaChampionsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x155554]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsSewersMohgDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x15D060]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsSpiritLorettaDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x67A1B]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsCommanderOneilDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xDCB27]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsGraftedScionDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x152098]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsSentinelDuoDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x9B1D6]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsCrucibleMisbegottenDuoDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xED5C1]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsElemerBriarDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x8AAA7]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsPutridCrystalTrioDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x172FF0]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsWormFaceDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xA483A]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsRoyalRevenantDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x5EA8D]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsDragonkinSoldierDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstboss = er.GetOffsets(eventflag, [0x28, 0x1550F2]);
            long secondboss = er.GetOffsets(eventflag, [0x28, 0x154C90]);
            bool flag = ((er.ReadByte(firstboss) & (1 << 1)) != 0) ||
                ((er.ReadByte(secondboss) & (1 << 5)) != 0);
            return flag;
        }
        public static bool IsMagmaWyrmDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstboss = er.GetOffsets(eventflag, [0x28, 0x179DCD]); //Gael Tunnel
            long secondboss = er.GetOffsets(eventflag, [0x28, 0x6845C]); //Mt. Gelmir
            long thirdboss = er.GetOffsets(eventflag, [0x28, 0x15DD8F]); //Makar
            bool flag = ((er.ReadByte(firstboss) & (1 << 7)) != 0) ||
                ((er.ReadByte(secondboss) & (1 << 7)) != 0) ||
                ((er.ReadByte(thirdboss) & (1 << 7)) != 0);
            return flag;
        }
        public static bool IsFallingstarBeastDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstboss = er.GetOffsets(eventflag, [0x28, 0x17A232]);
            long secondboss = er.GetOffsets(eventflag, [0x28, 0x9AE6B]);
            bool flag = ((er.ReadByte(firstboss) & (1 << 7)) != 0) ||
                ((er.ReadByte(secondboss) & (1 << 7)) != 0);
            return flag;
        }
        public static bool IsBlackBladeKindredDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstboss = er.GetOffsets(eventflag, [0x28, 0xEEDAE]);
            long secondboss = er.GetOffsets(eventflag, [0x28, 0xDFB01]);
            bool flag = ((er.ReadByte(firstboss) & (1 << 7)) != 0) ||
                ((er.ReadByte(secondboss) & (1 << 7)) != 0);
            return flag;
        }
        public static bool IsOmenkillerDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x65EC3]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsMorgottDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x152DC7]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsAncestorSpiritDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x156B4D]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool IsRealMohgDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x155E1E]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
    }
}
