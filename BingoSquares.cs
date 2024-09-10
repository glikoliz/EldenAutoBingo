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
            for (int i = 0; i < npcs.Length; i++)
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
        public static bool MimicConsumablesOnly()
        {
            long bossaddr = constants.GetCurrentBoss();
            long currentboss = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentboss);
            int currentanim = er.ReadInt(constants.GetPlayerAnim());
            long isdeadaddr = constants.IsBossDeadAddr(currentbossaddr);

            while (currentboss == ERConstants.MIMIC_PARAM_ID)
            {
                currentboss = er.ReadInt(bossaddr);
                currentanim = er.ReadInt(constants.GetPlayerAnim());
                if (currentanim >= 20000000 && currentanim <= 900000000)
                {
                    if ((currentanim / 10000) % 10 == 3 || (currentanim / 1000) % 100 == 45)
                    {
                        Console.WriteLine("No consumable");
                        Thread.Sleep(1000);
                        return false;
                    }
                }
                if (er.ReadByte(isdeadaddr) == 1)
                {
                    Console.WriteLine("Mimic killed");
                    return true;
                }
                Thread.Sleep(500);
            }
            return true;
        }
        public static bool KilledWithFlask()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            while (currentbossid != 0)
            {
                currentbossid = er.ReadInt(bossaddr);
                bool explosive = constants.FindExplosiveFlaskEffect();
                int prevbosshp = constants.GetEnemyHP(currentbossaddr);
                while (explosive)
                {
                    explosive = constants.FindExplosiveFlaskEffect();
                    Thread.Sleep(1000);
                    int bosshp = constants.GetEnemyHP(currentbossaddr);
                    if (prevbosshp > 0 && bosshp == 0)
                    {
                        Console.WriteLine("Killed with flask");
                        return true;
                    }
                }
                Thread.Sleep(1000);
            }
            return false;
        }
        public static bool SoldierOfGodBareFist()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            long isdeadaddr = constants.IsBossDeadAddr(currentbossaddr);
            int current_weapon;

            while (currentbossid == ERConstants.SOLDIER_OF_GOD_PARAM_ID)
            {
                currentbossid = er.ReadInt(bossaddr);
                current_weapon = constants.GetCurrentWeaponId();
                if (current_weapon != 110000)
                {
                    Console.WriteLine("NOT FISTS");
                    return false;
                }
                if (er.ReadByte(isdeadaddr) == 1)
                {
                    Console.WriteLine("GOD killed");
                    return true;
                }
            }
            return false;
        }
        public static bool TreeSentintel0Weapon()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            long isdeadaddr = constants.IsBossDeadAddr(currentbossaddr);
            int current_weapon;
            Thread.Sleep(5000);
            while (currentbossid == ERConstants.LIMGRAVE_TREE_SENTINTEL_PARAM_ID)
            {
                currentbossid = er.ReadInt(bossaddr);
                current_weapon = constants.GetCurrentWeaponId();
                if (current_weapon % 100 != 0)
                {
                    Console.WriteLine("NOT +0");
                    return false;
                }
                if (er.ReadByte(isdeadaddr) == 1)
                {
                    Console.WriteLine("Tree Sentinel killed");
                    return true;
                }
                Thread.Sleep(2000);
            }
            return false;
        }
        public static bool Agheel0Weapon()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            long isdeadaddr = constants.IsBossDeadAddr(currentbossaddr);
            int current_weapon;
            Thread.Sleep(5000);
            while (currentbossid == ERConstants.AGHEEL_PARAM_ID)
            {
                currentbossid = er.ReadInt(bossaddr);
                current_weapon = constants.GetCurrentWeaponId();
                if (current_weapon % 100 != 0)
                {
                    Console.WriteLine("NOT +0");
                    return false;
                }
                if (er.ReadByte(isdeadaddr) == 1)
                {
                    Console.WriteLine("Agheel killed");
                    return true;
                }
                Thread.Sleep(2000);
            }
            return false;
        }

        public static bool DeathBirdsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] deathBirds = [0xA0E1F, 0xB0B0D, 0x77033, 0xB52D4];
            int[] deathRiteBirds = [0x6F1BC, 0xE94D0, 0xD8360];
            int count = 0b00;
            long boss;
            foreach (var addr in deathBirds)
            {
                boss = baseAddr + addr;
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                {
                    count |= 0b10;
                    break;
                }
            }
            foreach (var addr in deathRiteBirds)
            {
                boss = baseAddr + addr;
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                {
                    count |= 0b01;
                    break;
                }
            }
            boss = baseAddr + 0xDC7C2;
            if ((er.ReadByte(boss) & (1 << 5)) != 0)
                count |= 0b01;

            if (count == 0b11)
                return true;

            return false;
        }
        public static bool CemeteryShadesDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] shades = [0x167BC3, 0x1691BC, 0x16BDAE];
            int count = 0;
            long boss;
            foreach (var addr in shades)
            {
                boss = baseAddr + addr;
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                    count++;
            }

            if (count >= 2)
            {
                Console.WriteLine("Yes");
                return true;
            }
            Console.WriteLine("NO");
            return false;
        }
        public static bool WatchdogsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0x16848D, 0x168028, 0x169621, 0x169A86, 0x16B949];
            int count = 0;
            long boss;
            foreach (var addr in bosses)
            {
                boss = baseAddr + addr;
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                {
                    if (addr == 0x16B949) //2 dogs here
                        count++;
                    count++;
                }
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }
            Console.WriteLine("NO");
            return false;
        }
        public static bool DuelistsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0x17577D, 0x168D57, 0x16B4E4, 0x16CF42];
            int count = 0;
            long boss;
            foreach (var addr in bosses)
            {
                boss = baseAddr + addr;
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                    count++;
            }

            if (count >= 2)
            {
                Console.WriteLine("Yes");
                return true;
            }
            Console.WriteLine("NO");
            return false;
        }
        public static bool BlackAssassinsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0x16AC1A, 0x174EB3, 0x92C89];
            int count = 0;
            long boss;
            foreach (var addr in bosses)
            {
                boss = baseAddr + addr;
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                    count++;
            }

            boss = baseAddr + 0x1691C2;
            if ((er.ReadByte(boss) & (1 << 5)) != 0)
                count++;

            if (count >= 2)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            return false;
        }
        public static bool CrucibleKnightsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0x151C0D, 0x1550C1, 0x1550C0, 0x1573D7, 0x1573D8, 0xED5C1, 0xA0AB4, 0x16A7B5, 0x155520, 0x152DA1, 0x152DA0, 0x159F49];
            int[] bytes = [5, 5, 1, 0, 7, 7, 7, 7, 1, 7, 0, 7];
            int count = 0;
            long boss;
            for (int i = 0; i < bosses.Length; i++)
            {
                boss = baseAddr + bosses[i];
                if ((er.ReadByte(boss) & (1 << bytes[i])) != 0)
                {
                    //Console.WriteLine(bosses[i].ToString("X8"));
                    if (bosses[i] == 0x16A7B5) //2 knights here
                        count++;
                    count++;
                }
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            return false;

            /* Замок 151C0D 5
             * Нокрон 1550C1 5
             * Горгульи 1550C0 1
             * Фарум 1573D7 0
             * Фарум 1573D8 7
             * ED5C1 7
             * A0AB4 7
             * 16A7B5 7  tut dwa
             * 155520 1
             * 152DA1 7
             * 152DA0 0
             * 159F49 7
             */
        }
        public static bool DragonHeartsDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0xA9001, 0xD3F04, 0xF6F90, 0x179DCD, 0x6845C, 0x15DD8F, 0x5D60B, 0x5E04C, 0x1AA7A2, 0xE9165];
            int count = 0;
            long boss;
            foreach (var addr in bosses)
            {
                boss = baseAddr + addr;
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                    count++;
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            return false;
            /* A9001 7
             * D3F04 7
             * F6F90 7
             * 179DCD 7
             * 6845C 7
             * 159B80 7 vulkan ////
             * 15DD8F 7 makar
             * 5D60B 7
             * 5E04C 7
             * 1AA7A2 7
             * E9165 7
             */
        }
        public static bool ErdtreeAvatarDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0xA85C0, 0x80D6D, 0x550BE, 0xFA2D5, 0x155520, 0x152D93];
            int[] bytes = [7, 7, 7, 7, 0, 2];
            int count = 0;
            long boss;
            for (int i = 0; i < bosses.Length; i++)
            {
                boss = baseAddr + bosses[i];
                if ((er.ReadByte(boss) & (1 << bytes[i])) != 0)
                    count++;
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            /* A85C0 7
             * 80D6D 7
             * 550BE 7
             * FA2D5 7
             * 155520 0
             * 152D93 2
             */
            return false;
        }
        public static bool NightCavalryDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0xA936C, 0x158146, 0x8850E, 0xDC7BC, 0x8A066, 0xD6EDE, 0x1ABD9B, 0xF6F96, 0xB0B13];
            int[] bytes = [7, 7, 7, 7, 7, 7, 7, 5, 5];
            int count = 0;
            long boss;
            for (int i = 0; i < bosses.Length; i++)
            {
                boss = baseAddr + bosses[i];
                if ((er.ReadByte(boss) & (1 << bytes[i])) != 0)
                {
                    if (bosses[i] == 0x1ABD9B)
                        count++;
                    count++;
                }
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            /* A936C 7
             * 158146 7
             * 8850E 7
             * DC7BC 7
             * 8A066 7
             * D6EDE 7
             * 1ABD9B 7 //two
             * F6F96 5
             * B0B13 5
             */
            return false;
        }
        public static bool TibiaMarinerDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0xBABB2, 0x88879, 0x81B19, 0xF1D58];
            int[] bytes = [7, 7, 7, 2];
            int count = 0;
            long boss;
            for (int i = 0; i < bosses.Length; i++)
            {
                boss = baseAddr + bosses[i];
                if ((er.ReadByte(boss) & (1 << bytes[i])) != 0)
                    count++;
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");

            /* BABB2 7
             * 88879 7
             * 81B19 7
             * F1D58 2
             */
            return false;
        }
        public static bool BellBearingDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);

            int[] bosses = [0xA0E25, 0x77DDF, 0xACA1C, 0xD4CB0];
            int count = 0;
            long boss;
            for (int i = 0; i < bosses.Length; i++)
            {
                boss = baseAddr + bosses[i];
                if ((er.ReadByte(boss) & (1 << 7)) != 0)
                    count++;
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");

            return false;
        }
        public static bool DuoTrioDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);
            var bossesData = new (int Boss, int Bytes)[]
            {
                (0x1ABD9B, 7),
                (0x16B949, 7),
                (0x16B07F, 7),
                (0xDCE92, 7),
                (0xD4945, 7),
                (0x1719F7, 7),
                (0x172FF0, 7),
                (0x179968, 7),
                (0x9B1D6, 7),
                (0xED5C1, 7),
                (0x171E5C, 7),
                (0x16A7B5, 7),
                (0x1550EF, 7),
                (0x175318, 7),
                (0x174A4E, 7),
                (0x175BE2, 7),
                (0x155554, 7),
                (0x174184, 7),
                (0x15741D, 5),
                (0x163579, 5),
                (0x159BAB, 3)
            };

            int count = 0;
            long boss;

            foreach (var (bossValue, bytes) in bossesData)
            {
                boss = baseAddr + bossValue;
                if ((er.ReadByte(boss) & (1 << bytes)) != 0)
                    count++;
            }

            if (count >= 3)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            return false;
        }
        public static bool HorseRidersDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);
            var bossesData = new (int Boss, int Bytes)[]
            {
                (0x1A1B02, 7),
                (0xA0749, 7),
                (0x9B1D6, 7),
                (0xA936C, 7),
                (0x158146, 7),
                (0x8850E, 7),
                (0xDC7BC, 7),
                (0x8A066, 7),
                (0xD6EDE, 7),
                (0x1ABD9B, 7),
                (0x67A1B, 7),
                (0xBD821, 7),
                (0xF6F96, 5),
                (0xB0B13, 5),
                (0x158E7B, 5)
            };

            int count = 0;
            foreach (var (boss, bytes) in bossesData)
            {
                long bossAddr = baseAddr + boss;
                if ((er.ReadByte(bossAddr) & (1 << bytes)) != 0)
                {
                    if (boss == 0x9B1D6 || boss == 0x1ABD9B)
                        count++;
                    count++;
                }
            }

            if (count >= 5)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            return false;
        }
        public static bool TreeBossesDead()
        {
            long eventflag = er.ReadLong(constants.GetEventflagman());
            long baseAddr = er.ReadLong(eventflag + 0x28);
            var bossesData = new (int Boss, int Bytes)[]
            {
                (0x16848D, 7),
                (0x168028, 7),
                (0x169621, 7),
                (0x16B949, 7),
                (0x169A86, 7),
                (0xA0749, 7),
                (0x9B1D6, 7),
                (0x15B602, 7),
                (0x16CADD, 7),
                (0xA85C0, 7),
                (0x80D6D, 7),
                (0x550BE, 7),
                (0xFA2D5, 5),
                (0xBD821, 7),
                (0x158E7B, 5),
                (0x79938, 5)
            };

            int count = 0;
            foreach (var (boss, bytes) in bossesData)
            {
                long bossAddr = baseAddr + boss;
                if ((er.ReadByte(bossAddr) & (1 << bytes)) != 0)
                {
                    if (boss == 0x16B949 || boss == 0x9B1D6)
                        count++;
                    count++;
                }
            }

            if (count >= 5)
            {
                Console.WriteLine("Yes");
                return true;
            }

            Console.WriteLine("NO");
            return false;
        }
        public static bool RemembranceBossHitless()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            bool isdead;
            float damageRate = er.ReadFloat(constants.GetPlayerDamageRate());
            float prevDamageRate = damageRate;
            while (ERConstants.REMEMBRANCE_BOSSES_PARAM_ID.Contains(currentbossid))
            {
                damageRate = er.ReadFloat(constants.GetPlayerDamageRate());
                currentbossid = er.ReadInt(bossaddr);
                if (currentbossid != 0)
                    currentbossaddr = constants.FindAddrById(currentbossid);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                if(damageRate!=prevDamageRate && damageRate!=0)
                {
                    Console.WriteLine("Hit");
                    Thread.Sleep(1000);
                    return false;
                }
                if (isdead)
                {
                    Console.WriteLine("Killed hitless");
                    return true;
                }
                Console.WriteLine(isdead);
                Thread.Sleep(500);

            }
            return false;
        }
        public static bool RemembranceCollosalWeapon()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            bool isdead;
            int current_weapon;
            Thread.Sleep(5000);
            while (ERConstants.REMEMBRANCE_BOSSES_PARAM_ID.Contains(currentbossid))
            {
                current_weapon = constants.GetCurrentWeaponId();
                currentbossid = er.ReadInt(bossaddr);
                if (currentbossid != 0)
                    currentbossaddr = constants.FindAddrById(currentbossid);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                if (current_weapon / 1000000 != 23)
                {
                    Console.WriteLine("NOT COLLOSAL");
                    return false;
                }
                if (isdead)
                {
                    Console.WriteLine("Boss killed");
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }
        public static bool RemembranceDaggersFists()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            bool isdead;
            int current_weapon;
            Thread.Sleep(5000);
            while (ERConstants.REMEMBRANCE_BOSSES_PARAM_ID.Contains(currentbossid))
            {
                current_weapon = constants.GetCurrentWeaponId();
                currentbossid = er.ReadInt(bossaddr);
                if (currentbossid != 0)
                    currentbossaddr = constants.FindAddrById(currentbossid);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                if (current_weapon / 1000000 != 1 && current_weapon / 1000000 != 22 && current_weapon!=110000)
                {
                    Console.WriteLine("NOT Daggers/claws");
                    return false;
                }
                if (isdead)
                {
                    Console.WriteLine("Boss killed");
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }
        public static bool RemembranceBowOnly()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            bool isdead;
            int current_weapon;
            Thread.Sleep(5000);
            while (ERConstants.REMEMBRANCE_BOSSES_PARAM_ID.Contains(currentbossid))
            {
                current_weapon = constants.GetCurrentWeaponId();
                currentbossid = er.ReadInt(bossaddr);
                if (currentbossid != 0)
                    currentbossaddr = constants.FindAddrById(currentbossid);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                if (current_weapon / 1000000 != 40 && current_weapon / 1000000 != 41 && current_weapon /1000000 != 42)
                {
                    Console.WriteLine("NOT bow");
                    return false;
                }
                if (isdead)
                {
                    Console.WriteLine("Boss killed");
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }
    }
}
