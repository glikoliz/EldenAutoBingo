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
        public static bool RedWolfDead() => IsBossDead([0x15814C], 5);
        public static bool GodskinApostleDead() => IsBossDead([0xA483A, 0x16310E], 7);
        public static bool GoldenGodfreyDead() => IsBossDead([0x152DCD], 5);
        public static bool FiaChampionsDead() => IsBossDead([0x155554], 7);
        public static bool SewersMohgDead() => IsBossDead([0x15D060], 7);
        public static bool SpiritLorettaDead() => IsBossDead([0x67A1B], 7);
        public static bool CommanderOneilDead() => IsBossDead([0xDCB27], 7);
        public static bool GraftedScionDead() => IsBossDead([0x152098], 7);
        public static bool SentinelDuoDead() => IsBossDead([0x9B1D6], 7);
        public static bool CrucibleMisbegottenDuoDead() => IsBossDead([0xED5C1], 7);
        public static bool ElemerBriarDead() => IsBossDead([0x8AAA7], 7);
        public static bool PutridCrystalTrioDead() => IsBossDead([0x172FF0], 7);
        public static bool WormFaceDead() => IsBossDead([0xA483A], 7);
        public static bool RoyalRevenantDead() => IsBossDead([0x5EA8D], 7);
        public static bool DragonkinSoldierDead() => IsBossDead([0x1550F2, 0x154C90], 1) || IsBossDead([0x1550F2, 0x154C90], 5);
        public static bool MagmaWyrmDead() => IsBossDead([0x179DCD, 0x6845C, 0x15DD8F], 7);
        public static bool FallingstarBeastDead() => IsBossDead([0x17A232, 0x9AE6B], 7);
        public static bool BlackBladeKindredDead() => IsBossDead([0xEEDAE, 0xDFB01], 7);
        public static bool OmenkillerDead() => IsBossDead([0x65EC3], 7);
        public static bool MorgottDead() => IsBossDead([0x152DC7], 7);
        public static bool AncestorSpiritDead() => IsBossDead([0x156B4D], 7);
        public static bool RealMohgDead() => IsBossDead([0x155E1E], 7);
        public static bool ValiantGargoylesDead() => IsBossDead([0x1550EF], 7);

        public static bool DeathBirdsDead() => IsBossDead([0xA0E1F, 0xB0B0D, 0x77033, 0xB52D4], 7) //Death Birds
        && (IsBossDead([0x6F1BC, 0xE94D0, 0xD8360], 7) || IsBossDead([0xDC7C2], 5)); //Death Rite Birds

        public static bool CemeteryShadesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x167BC3, 7, 1),
                (0x1691BC, 7, 1),
                (0x16BDAE, 7, 1)
            };
            return KilledBossesCount(bossesData) >= 2;
        }
        public static bool WatchdogsDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x16848D, 7, 1),
                (0x168028, 7, 1),
                (0x169621, 7, 1),
                (0x169A86, 7, 1),
                (0x16B949, 7, 2)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool DuelistsDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x17577D, 7, 1),
                (0x168D57, 7, 1),
                (0x16B4E4, 7, 1),
                (0x16CF42, 7, 1)
            };
            return KilledBossesCount(bossesData) >= 2;
        }
        public static bool BlackAssassinsDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x16AC1A, 7, 1),
                (0x174EB3, 7, 1),
                (0x92C89, 7, 1),
                (0x1691C2, 5, 1)
            };
            return KilledBossesCount(bossesData) >= 2;
        }
        public static bool CrucibleKnightsDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x151C0D, 5, 1),
                (0x1550C1, 5, 1),
                (0x1550C0, 1, 1),
                (0x1573D7, 0, 1),
                (0x1573D8, 7, 1),
                (0xED5C1, 7, 1),
                (0xA0AB4, 7, 1),
                (0x16A7B5, 7, 2),
                (0x155520, 1, 1),
                (0x152DA1, 7, 1),
                (0x152DA0, 0, 1),
                (0x159F49, 7, 1)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool DragonHeartsDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0xA9001, 7, 1),
                (0xD3F04, 7, 1),
                (0xF6F90, 7, 1),
                (0x179DCD, 7, 1),
                (0x6845C, 7, 1),
                (0x15DD8F, 7, 1),
                (0x5D60B, 7, 1),
                (0x5E04C, 7, 1),
                (0x1AA7A2, 7, 1),
                (0xE9165, 7, 1)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool ErdtreeAvatarDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0xA85C0, 7, 1),
                (0x80D6D, 7, 1),
                (0x550BE, 7, 1),
                (0xFA2D5, 7, 1),
                (0x155520, 0, 1),
                (0x152D93, 2, 1)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool NightCavalryDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0xA936C, 7, 1),
                (0x158146, 7, 1),
                (0x8850E, 7, 1),
                (0xDC7BC, 7, 1),
                (0x8A066, 7, 1),
                (0xD6EDE, 7, 1),
                (0x1ABD9B, 7, 2),
                (0xF6F96, 5, 1),
                (0xB0B13, 5, 1)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool TibiaMarinerDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0xBABB2, 7, 1),
                (0x88879, 7, 1),
                (0x81B19, 7, 1),
                (0xF1D58, 2, 1)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool BellBearingDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0xA0E25, 7, 1),
                (0x77DDF, 7, 1),
                (0xACA1C, 7, 1),
                (0xD4CB0, 7, 1)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool DuoTrioDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x1ABD9B, 7, 1),
                (0x16B949, 7, 1),
                (0x16B07F, 7, 1),
                (0xDCE92, 7, 1),
                (0xD4945, 7, 1),
                (0x1719F7, 7, 1),
                (0x172FF0, 7, 1),
                (0x179968, 7, 1),
                (0x9B1D6, 7, 1),
                (0xED5C1, 7, 1),
                (0x171E5C, 7, 1),
                (0x16A7B5, 7, 1),
                (0x1550EF, 7, 1),
                (0x175318, 7, 1),
                (0x174A4E, 7, 1),
                (0x175BE2, 7, 1),
                (0x155554, 7, 1),
                (0x174184, 7, 1),
                (0x15741D, 5, 1),
                (0x163579, 5, 1),
                (0x159BAB, 3, 1)
            };
            return KilledBossesCount(bossesData) >= 3;
        }
        public static bool HorseRidersDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x1A1B02, 7, 1),
                (0xA0749, 7, 1),
                (0x9B1D6, 7, 2),
                (0xA936C, 7, 1),
                (0x158146, 7, 1),
                (0x8850E, 7, 1),
                (0xDC7BC, 7, 1),
                (0x8A066, 7, 1),
                (0xD6EDE, 7, 1),
                (0x1ABD9B, 7, 2),
                (0x67A1B, 7, 1),
                (0xBD821, 7, 1),
                (0xF6F96, 5, 1),
                (0xB0B13, 5, 1),
                (0x158E7B, 5, 1)
            };
            return KilledBossesCount(bossesData) >= 5;
        }
        public static bool TreeBossesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x16848D, 7, 1),
                (0x168028, 7, 1),
                (0x169621, 7, 1),
                (0x16B949, 7, 2),
                (0x169A86, 7, 1),
                (0xA0749, 7, 1),
                (0x9B1D6, 7, 2),
                (0x15B602, 7, 1),
                (0x16CADD, 7, 1),
                (0xA85C0, 7, 1),
                (0x80D6D, 7, 1),
                (0x550BE, 7, 1),
                (0xBD821, 7, 1),
                (0xFA2D5, 5, 1),
                (0x158E7B, 5, 1),
                (0x79938, 5, 1)
            };
            return KilledBossesCount(bossesData) >= 5;
        }
        public static bool GodskinNobleKilledWithousStatus()
        {
            long bossaddr = constants.GetCurrentBoss();
            long currentboss = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentboss);
            bool check = false;
            bool isdead;
            while (currentboss == (int)ERConstants.BossId.GodskinNobleVolcano)
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

            while (currentboss == (int)ERConstants.BossId.Margit)
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
            long nepheliaddr = constants.FindAddrById((int)ERConstants.BossId.Nepheli);
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
            while (currentboss == (int)ERConstants.BossId.Godrick)
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

            while (currentboss == (int)ERConstants.BossId.Renalla)
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
            while (currentboss == (int)ERConstants.BossId.Radahn)
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

            while (currentboss == (int)ERConstants.BossId.Mimic)
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

            while (currentbossid == (int)ERConstants.BossId.SoldierOfGod)
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
            while (currentbossid == (int)ERConstants.BossId.LimgraveTreeSentinel)
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
            while (currentbossid == (int)ERConstants.BossId.Agheel)
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
            int currentanim;
            while (ERConstants.REMEMBRANCE_BOSSES_PARAM_ID.Contains(currentbossid))
            {
                currentanim = er.ReadInt(constants.GetPlayerAnim());

                current_weapon = constants.GetCurrentWeaponId();
                currentbossid = er.ReadInt(bossaddr);
                if (currentbossid != 0)
                    currentbossaddr = constants.FindAddrById(currentbossid);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;

                if (currentanim / 10000 % 10 == 3 && current_weapon / 1000000 != 1 && current_weapon / 1000000 != 22 && current_weapon!=110000)
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
        public static bool RemembranceIncantations()
        {
            long bossaddr = constants.GetCurrentBoss();
            int currentbossid = er.ReadInt(bossaddr);
            long currentbossaddr = constants.FindAddrById(currentbossid);
            bool isdead;
            int currentanim;
            Thread.Sleep(5000);
            while (ERConstants.REMEMBRANCE_BOSSES_PARAM_ID.Contains(currentbossid))
            {
                currentbossid = er.ReadInt(bossaddr);
                currentanim = er.ReadInt(constants.GetPlayerAnim());

                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;

                if ((currentanim / 10000) % 10 == 3)
                {
                    Console.WriteLine("Not incantations");
                    return false;
                }
                if (isdead)
                {
                    Console.WriteLine("GOD killed");
                    return true;
                }
            }
            return false;
        }

    }
}