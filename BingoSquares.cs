using System.Collections.Concurrent;

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

        public static bool LeonineDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xA7B7F]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }

        public static bool RedWolfDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x15814C]);
            bool flag = (er.ReadByte(boss) & (1 << 5)) != 0;
            return flag;
        }

        public static bool GodskinApostleDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstApostle = er.GetOffsets(eventflag, [0x28, 0xA483A]);
            long secondApostle = er.GetOffsets(eventflag, [0x28, 0x16310E]);
            bool flag = ((er.ReadByte(firstApostle) & (1 << 7)) != 0) ||
                ((er.ReadByte(secondApostle) & (1 << 7)) != 0);
            return flag;
        }
        public static bool GoldenGodfreyDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x152DCD]);
            bool flag = (er.ReadByte(boss) & (1 << 5)) != 0;
            return flag;
        }
        public static bool FiaChampionsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x155554]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool SewersMohgDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x15D060]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool SpiritLorettaDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x67A1B]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool CommanderOneilDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xDCB27]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool GraftedScionDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x152098]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool SentinelDuoDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x9B1D6]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool CrucibleMisbegottenDuoDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xED5C1]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool ElemerBriarDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x8AAA7]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool PutridCrystalTrioDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x172FF0]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool WormFaceDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0xA483A]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool RoyalRevenantDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x5EA8D]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool DragonkinSoldierDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstboss = er.GetOffsets(eventflag, [0x28, 0x1550F2]);
            long secondboss = er.GetOffsets(eventflag, [0x28, 0x154C90]);
            bool flag = ((er.ReadByte(firstboss) & (1 << 1)) != 0) ||
                ((er.ReadByte(secondboss) & (1 << 5)) != 0);
            return flag;
        }
        public static bool MagmaWyrmDead()
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
        public static bool FallingstarBeastDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstboss = er.GetOffsets(eventflag, [0x28, 0x17A232]);
            long secondboss = er.GetOffsets(eventflag, [0x28, 0x9AE6B]);
            bool flag = ((er.ReadByte(firstboss) & (1 << 7)) != 0) ||
                ((er.ReadByte(secondboss) & (1 << 7)) != 0);
            return flag;
        }
        public static bool BlackBladeKindredDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long firstboss = er.GetOffsets(eventflag, [0x28, 0xEEDAE]);
            long secondboss = er.GetOffsets(eventflag, [0x28, 0xDFB01]);
            bool flag = ((er.ReadByte(firstboss) & (1 << 7)) != 0) ||
                ((er.ReadByte(secondboss) & (1 << 7)) != 0);
            return flag;
        }
        public static bool OmenkillerDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x65EC3]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool MorgottDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x152DC7]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool AncestorSpiritDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x156B4D]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool RealMohgDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x155E1E]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }
        public static bool ValiantGargoylesDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long boss = er.GetOffsets(eventflag, [0x28, 0x1550EF]);
            bool flag = (er.ReadByte(boss) & (1 << 7)) != 0;
            return flag;
        }

        public static bool GodskinNobleKilledWithousStatus()
        {
            long bossaddr = constants.GetCurrentBoss();
            long currentboss = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentboss);
            bool check = false;
            bool isdead;
            while (currentboss == ERConstants.GODSKIN_NOBLE_VOLCANO_PARAM_ID)
            {
                currentboss = er.ReadInt(bossaddr);
                check = constants.IsStatusEffectUsed(currentbossaddr);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                if (check)
                {
                    return false;
                }
                else if (isdead)
                {
                    Console.WriteLine("Noble was killed without status effects");
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }


        public static bool MargitKilledWithParries()
        {
            long bossaddr = constants.GetCurrentBoss();
            long currentboss = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentboss);
            int parry_count = 0;
            int currentAnimation;
            bool isdead;

            while (currentboss == ERConstants.MARGIT_PARAM_ID)
            {
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                currentboss = er.ReadInt(bossaddr);
                currentAnimation = constants.GetEnemyCurrentAnim(currentbossaddr);
                if (currentAnimation == ERConstants.MARGIT_PARRY_ANIM1 || currentAnimation == ERConstants.MARGIT_PARRY_ANIM2)
                {
                    parry_count++;
                    Console.WriteLine(parry_count);
                    while (currentAnimation == ERConstants.MARGIT_PARRY_ANIM1 || currentAnimation == ERConstants.MARGIT_PARRY_ANIM2)
                    {
                        currentAnimation = constants.GetEnemyCurrentAnim(currentbossaddr);
                        Thread.Sleep(1000);
                    }

                }
                if (isdead)
                {
                    if (parry_count >= 4)
                    {
                        Console.WriteLine("Margit was killed with 4+ parries");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("You killed him without parries");
                        return false;
                    }

                }
                Thread.Sleep(100);
            }
            return false;
        }
        public static bool GodrickKilledWithNepheli()
        {
            long bossaddr = constants.GetCurrentBoss();
            long currentboss = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentboss);
            long nepheliaddr = constants.FindAddrById(ERConstants.NEPHELI_PARAM_ID);
            bool isnephelihere = er.ReadInt(er.GetOffsets(nepheliaddr, [0x190, 0x18, 0x40])) != -1;
            bool isdead;
            if (!isnephelihere)
            {
                Console.WriteLine("Nepheli wasn't summoned");
                return false;
            }
            else
            {
                Console.WriteLine("Nepheli summoned");
            }
            while (currentboss == ERConstants.GODRICK_PARAM_ID)
            {
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                currentboss = er.ReadInt(bossaddr);
                if (isdead)
                {
                    Console.WriteLine("Godrick was killed with Nepheli");
                    return true;
                }
                Thread.Sleep(1000);

            }
            return false;
        }
        public static bool RenallaKilledAfterSummons()
        {
            long bossaddr = constants.GetCurrentBoss();
            long currentboss = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentboss);
            int summons = 0b0000;
            bool isdead;
            var summonData = new (int AnimationId, int Mask)[]
            {
                (3030, 0b1000), //dragon
                (3031, 0b0100), //bloodhound
                (3032, 0b0010), //gigant
                (3033, 0b0001) //wolves
            };

            while (currentboss == ERConstants.RENALLA_PARAM_ID)
            {
                int currentanimation = constants.GetEnemyCurrentAnim(currentbossaddr);
                currentboss = er.ReadInt(bossaddr);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                foreach (var (animationId, mask) in summonData)
                {
                    if (currentanimation == animationId && (summons & mask) == 0)
                    {
                        summons |= mask;
                    }
                }
                if (isdead)
                {
                    return summons == 0b1111;
                }
                Thread.Sleep(500);
            }

            return false;
        }
        public static bool RadahnKilledWithoutSummons()
        {
            long bossaddr = constants.GetCurrentBoss();
            long currentboss = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentboss);
            long isdeadaddr = constants.IsBossDeadAddr(currentbossaddr);
            long[] npcs = [533440040, 533290040, 533550040, 44909040, 533630040, 533090040, 20109140];
            //533440040 Tragott
            //533290040 Lionel
            //533550040 Okina
            //44909040 Alexander
            //533630040 Maiden
            //533090040 Patches
            //20109140 Blaidd
            long[] npcAdressess = new long[npcs.Length];
            for (int i = 0; i<npcs.Length;i++)
            {
                npcAdressess[i] = constants.FindAddrById(npcs[i]);
            }
            while (currentboss == ERConstants.RADAHN_PARAM_ID)
            {
                currentboss = er.ReadInt(bossaddr);
                foreach (var npcaddr in npcAdressess)
                {
                    byte alliance = constants.GetNpcAlliance(npcaddr);
                    if (alliance == 2)
                    {
                        return false;
                    }
                }
                if (er.ReadByte(isdeadaddr) == 1)
                {
                    Console.WriteLine("Radahn killed without summons");
                    return true;
                }
                Thread.Sleep(3000);
            }
            return false;
        }


    }
}
