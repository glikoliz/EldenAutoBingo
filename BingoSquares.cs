using Newtonsoft.Json.Serialization;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Elden_Ring_Auto_Bingo
{
    public static class BingoSquares
    {
        private static ERMemoryReader er = new ERMemoryReader(new ERProcessMonitor());
        private static ERConstants constants = new ERConstants(er);
        private static long eventFlag = er.ReadLong(constants.GetEventFlagMan());
        private static long dataMan = er.ReadLong(constants.GetGameDataMan());

        private static bool CheckFlag(int offset, int bitPosition)
        {
            long boss = er.GetOffsets(eventFlag, [0x28, offset]);
            return (er.ReadByte(boss) & (1 << bitPosition)) != 0;
        }
        private static int CountFlags((int Boss, int Byte, int Count)[] bossesData)
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
        public static bool LeonineDead() => CheckFlag(0xA7B7F, 7);
        public static bool GoldenHippoDead() => CheckFlag(0x477, 7);
        public static bool MidraDead() => CheckFlag(0x90, 3);
        public static bool RadahnDead() => CheckFlag(0x8E, 0);
        public static bool DancingLionDead() => CheckFlag(0x8E, 3) || CheckFlag(0x174F3, 7);
        public static bool AncientSenessaxDead() => CheckFlag(0x2DCD, 2);
        public static bool BlackKnightDead() => CheckFlag(0x2DE1, 2) || CheckFlag(0x2DE0, 4);
        public static bool JoriDead() => CheckFlag(0x91, 6);
        public static bool LamenterDead() => CheckFlag(0x9F, 2);
        public static bool DeathKnightDead() => CheckFlag(0x9E, 1) || CheckFlag(0x9E, 0);
        public static bool MariggaDead() => CheckFlag(0x2DD2, 2);
        public static bool BloodfiendDead() => CheckFlag(0xA0, 7);
        public static bool PutrescentKnightDead() => CheckFlag(0x8F, 3);
        public static bool DryleafDaneDead() => CheckFlag(0x25689, 7); //test this
        public static bool ScadutreeAvatarDead() => CheckFlag(0x91, 5);
        public static bool RellanaDead() => CheckFlag(0x47C, 1);
        public static bool MetyrDead() => CheckFlag(0x478, 4);
        public static bool MessmerDead() => CheckFlag(0x477, 5);
        public static bool SentinelDuoDead() => CheckFlag(0x2DDF, 1);
        public static bool RominaDead() => CheckFlag(0x91, 7);
        public static bool DragonManDead() => CheckFlag(0xA0, 6);
        public static bool DeathRiteBirdDead() => CheckFlag(0x1ABA3, 7);
        public static bool RedBearDead() => CheckFlag(0x2DD9, 3);
        public static bool FrenzyNPCDead() => CheckFlag(0x3310A, 3);
        public static bool LogurBeastClawDead() => CheckFlag(0x1AEE8, 4);
        public static bool BolsDead() => CheckFlag(0x1BC7C, 1);
        public static bool CarianKnightDead() => CheckFlag(0x1BC83, 7);
        public static bool LedaDead() => CheckFlag(0x3B9, 6);
        public static bool DemiSwordsmanDead() => CheckFlag(0x9F, 4); //1ADAF 4 for non-boss
        public static bool YmirDead() => CheckFlag(0x2F058, 7);
        public static bool QueelignDead() => CheckFlag(0x17AF13, 3);
        public static bool MausoleumsCompleted()        
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x2DD0, 1, 1), //Rakhasa
                (0x2DD9, 3, 1), //Red bear
                (0x16459, 7, 1), //Blackgaol
                (0x15A18, 3, 1), //Dancer
            };
            return CountFlags(bossesData) >= 2;
        }
        public static bool GaolsCompleted()        
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x9F, 2, 1), //Onze
                (0x9F, 3, 1), //Labirith
                (0x9F, 4, 1) //Lamenter
            };
            return CountFlags(bossesData) >= 2;
        }
        public static bool CatacombsCompleted()        
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x91, 6, 1), //Jori
                (0x9E, 0, 1), //Death Knight 1
                (0x9E, 1, 1) //Death Knight 2
            };
            return CountFlags(bossesData) >= 2;
        }
        public static bool ForgesCompleted()        
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x1835C1, 7, 1),
                (0x183E8B, 7, 1),
                (0x1842F0, 7, 1)
            };
            return CountFlags(bossesData) >= 2;
        }
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
            return CountFlags(bossesData) >= 4;
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
            return CountFlags(bossesData) >= 3;
        }
        public static bool DragonBossesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x2DD4, 3, 1), //Gravesite ghostflame dragon
                (0x25431, 3, 1), //Cerulean ghostflame dragon
                (0x2531E, 7, 1), //Scadu ghostflame
                (0x489, 5, 1), //Jagged drake peak
                (0x2DCD, 2, 1), //Sennessax
                (0x91, 4, 1), //Bayle
            };
            return CountFlags(bossesData) >= 3;
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
            return CountFlags(bossesData) >= 1;
        }
        public static bool BearLionHippoDead()
        {
            bool Bear = CheckFlag(0x2DDD, 5) || CheckFlag(0xDB24, 7);
            bool Lion = CheckFlag(0x8E, 3) || CheckFlag(0x174F3, 7);
            bool Hippo = CheckFlag(0x477, 7);
            return Bear && Lion && Hippo;
        }
        public static bool KnightBossesDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x16459, 7, 1),
                (0x47C, 1, 1),
                (0x2DE1, 2, 1),
                (0x2DE0, 4, 1),
                (0x9E, 1, 1),
                (0x9E, 0, 1),
                (0x8F, 3, 1)
            };
            return CountFlags(bossesData) >= 3;
        }
        public static bool GiantHandDead()
        {
            long handAddr = constants.FindAddrById(55510093);
            long handDeadAddr = er.GetOffsets(handAddr, [0x58, 0xC8, 0x24]);
            bool isDead = er.ReadByte(handDeadAddr) == 1;
            return isDead;
        }
        public static bool HipposDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x2ECAE, 3, 1),
                (0x2ECAF, 1, 1),
                (0x1AB64, 3, 1),
                (0x174B3, 5, 1),
                (0x477, 7, 1),
            };
            return CountFlags(bossesData) >= 2;
        }
        public static bool BayleWithIgonDead()
        {
            long bossAddr = constants.GetCurrentBoss();
            int currentBossId = er.ReadInt(bossAddr);
            long currentBossAddr = constants.FindAddrById(currentBossId);
            long isDeadAddr = constants.IsBossDeadAddr(currentBossAddr);
            while (currentBossId == (int)ERConstants.BossId.Bayle)
            {
                currentBossId = er.ReadInt(bossAddr);
                if (er.ReadByte(isDeadAddr) == 1)
                    return CheckFlag(0xC04E6, 7); //check if igon was summoned 
                Thread.Sleep(200);
            }
            return false;

        }
        public static bool ScaduLvl10() => er.ReadByte(er.GetOffsets(dataMan, [0x08, 0xFC])) >= 10;
        public static bool ReveredAshLvl5() => er.ReadByte(er.GetOffsets(dataMan, [0x08, 0xFD])) >= 5;
        public static bool PlayerLvl85() => er.ReadByte(er.GetOffsets(dataMan, [0x08, 0x68])) >= 85;
        public static bool TreeBurned() => CheckFlag(0x29, 5);
        public static bool EuporiaAcquired() => CheckFlag(0x17B214, 5);
        public static bool GoldenBraidAcquired() => CheckFlag(0x2F8FD, 1);
        public static bool TaylewAcquired() => CheckFlag(0x1842F0, 7);
        public static bool TrinaSwordAcquired() => CheckFlag(0x17D525, 1);
        public static bool DiscusAcquired() => CheckFlag(0x17A48, 7);
        public static bool GayPantsAcquired() => CheckFlag(0x267AC, 3);
        public static bool DevoniaAcquired() => CheckFlag(0x12B83, 7);
        public static bool RanahOilAcquired() => CheckFlag(0x15B33, 1);
        public static bool WaterDrainedFromChurch() => CheckFlag(0xF, 3);
        public static bool StTrinaTalked() => CheckFlag(0x17D62D, 0);
        public static bool HealKindredRot() => CheckFlag(0x26B, 0);
        public static bool ThiolliersDrink()
        {
            
            long addr = constants.GetPlayerAnim();
            return er.ReadInt(addr) == 17200;
        }



        public static bool WasTransformed()
        {
            int ok = constants.GetCurrentTransformation();
            return ok == 1058235609 || ok == 1058032249 || ok == 1057727209;
        }
        public static bool Visited5Crosses()
        {
            int count = 0;
            long addr = er.GetOffsets(eventFlag, [0x28, 0x266]);
            count += Convert.ToString(er.ReadByte(addr), 2).Count(c => c == '1');
            (int Boss, int Byte, int Count)[] bossesData =
{
                (0x265, 0, 1),
                (0x265, 1, 1),
                (0x267, 5, 1),
                (0x267, 6, 1),
                (0x267, 7, 1),
            };
            count += CountFlags(bossesData);
            Console.WriteLine(count);
            return count >= 5;
        }
        public static bool FullGravebirdAcquired()
        {
            (int Boss, int Byte, int Count)[] setData =
            {
                (0x12112, 3, 1),
                (0x20613, 3, 1),
                (0x25EF0, 5, 1),
                (0x17B68E, 3, 1),

            };
            return CountFlags(setData) == 4;
        }
        public static bool PaintingRewardsAcquired()
        {
            (int Boss, int Byte, int Count)[] rewardsData =
            {
                (0x300E, 3, 1),
                (0x300D, 5, 1),
                (0x300C, 7, 1),
            };
            return CountFlags(rewardsData) >= 2;
        }


        public static bool FurnaceGolemsDead()
        {
            (int Boss, int Byte, int Count)[] bossesData =
            {
                (0x2A853, 1, 1),
                (0x2A852, 3, 1),
            };//TODO
            return CountFlags(bossesData) >= 5;
        }
        public static bool RemembranceBossHitless() //TODO
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
                Console.WriteLine(currentbossaddr);
                isdead = er.ReadByte(constants.IsBossDeadAddr(currentbossaddr)) == 1;
                if (damageRate != prevDamageRate && damageRate != 0)
                {
                    Console.WriteLine("Hit");
                    Thread.Sleep(1000);
                    return false;
                }
                if (isdead)
                {
                    if(currentbossid == 52300196 || currentbossid == 52300496)//sunflower
                    {
                        currentbossaddr = constants.FindAddrById(currentbossid);
                        continue;
                    }
                    Console.WriteLine("Killed hitless");
                    return true;
                }
                Console.WriteLine(isdead);
                Thread.Sleep(500);

            }
            return false;
        }
    }
}//2F00A 3 npc in metyr location
 //524200190
 //2F058 7 count ymir