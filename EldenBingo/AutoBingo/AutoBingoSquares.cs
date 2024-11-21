using Newtonsoft.Json.Serialization;
using System.Reflection.Metadata.Ecma335;

namespace EldenBingo.AutoBingo
{
    public static class AutoBingoSquares
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class BingoSquareAttribute : Attribute
        {
            public string SquareName { get; }
            public BingoSquareAttribute(string squareName)
            {
                SquareName = squareName;
            }
        }
        private static ERMemoryReader er;
        private static ERConstants constants;
        private static ERProcessMonitor processMonitor;

        static AutoBingoSquares()
        {
            Initialize();
        }

        private static void Initialize()
        {
            processMonitor = new ERProcessMonitor();
            er = new ERMemoryReader(processMonitor);
            constants = new ERConstants(er);

            processMonitor.ProcessChanged += (s, e) => Initialize();
        }
        [BingoSquare("Kill the Golden Hippo")]
        public static bool GoldenHippoDead() => constants.CheckFlag(0x477, 7);
        [BingoSquare("Kill Midra, Lord of Frenzied Flame")]
        public static bool MidraDead() => constants.CheckFlag(0x90, 3);
        [BingoSquare("Kill Consort Radahn")]
        public static bool RadahnDead() => constants.CheckFlag(0x8E, 0);
        [BingoSquare("Kill a Dancing Lion")]
        public static bool DancingLionDead() => constants.CheckFlag(0x8E, 3) || constants.CheckFlag(0x174F3, 7);
        [BingoSquare("Kill Ancient Dragon Senessax")]
        public static bool AncientSenessaxDead() => constants.CheckFlag(0x2DCD, 2);
        [BingoSquare("Kill a Black Knight boss")]
        public static bool BlackKnightDead() => constants.CheckFlag(0x2DE1, 2) || constants.CheckFlag(0x2DE0, 4);
        [BingoSquare("Kill Jori, The Elder Inquisitor")]
        public static bool JoriDead() => constants.CheckFlag(0x91, 6);
        [BingoSquare("Kill Lamenter Boss")]
        public static bool LamenterDead() => constants.CheckFlag(0x9F, 2);
        [BingoSquare("Kill a Death Knight")]
        public static bool DeathKnightDead() => constants.CheckFlag(0x9E, 1) || constants.CheckFlag(0x9E, 0);
        [BingoSquare("Kill Demi Human Marigga")]
        public static bool MariggaDead() => constants.CheckFlag(0x2DD2, 2);
        [BingoSquare("Kill Chief Bloodfiend")]
        public static bool BloodfiendDead() => constants.CheckFlag(0xA0, 7);
        [BingoSquare("Kill Putrescent Knight")]
        public static bool PutrescentKnightDead() => constants.CheckFlag(0x8F, 3);
        [BingoSquare("Kill Dryleaf Dane in the Duel")]
        public static bool DryleafDaneDead() => constants.CheckFlag(0x25689, 7); //test this
        [BingoSquare("Kill Scadutree Avatar")]
        public static bool ScadutreeAvatarDead() => constants.CheckFlag(0x91, 5);
        [BingoSquare("Kill Rellana, Twin Moon Knight")]
        public static bool RellanaDead() => constants.CheckFlag(0x47C, 1);
        [BingoSquare("Kill Metyr, Mother of Fingers")]
        public static bool MetyrDead() => constants.CheckFlag(0x478, 4);
        [BingoSquare("Kill Messmer")]
        public static bool MessmerDead() => constants.CheckFlag(0x477, 5);
        [BingoSquare("Kill the Tree Sentinel Duo")]
        public static bool SentinelDuoDead() => constants.CheckFlag(0x2DDF, 1);
        [BingoSquare("Kill Romina")]
        public static bool RominaDead() => constants.CheckFlag(0x91, 7);
        [BingoSquare("Kill Ancient Dragon Man Boss")]
        public static bool DragonManDead() => constants.CheckFlag(0xA0, 6);
        [BingoSquare("Kill the Death Rite Bird")]
        public static bool DeathRiteBirdDead() => constants.CheckFlag(0x1ABA3, 7);
        [BingoSquare("Kill a Red bear")]
        public static bool RedBearDead() => constants.CheckFlag(0x2DD9, 3);
        [BingoSquare("Kill the Frenzy NPC")]
        public static bool FrenzyNPCDead() => constants.CheckFlag(0x3310A, 3);
        [BingoSquare("Kill Logur, the Beast Claw")]
        public static bool LogurBeastClawDead() => constants.CheckFlag(0x1AEE8, 4);
        [BingoSquare("Kill Bols in front of Castle Ensis")]
        public static bool BolsDead() => constants.CheckFlag(0x1BC7C, 1);
        [BingoSquare("Kill Moonrithyll, Carian Knight")]
        public static bool CarianKnightDead() => constants.CheckFlag(0x1BC83, 7);
        [BingoSquare("Kill Leda and her companions")]
        public static bool LedaDead() => constants.CheckFlag(0x3B9, 6);
        [BingoSquare("Kill a Demi Human Swordsman")]
        public static bool DemiSwordsmanDead() => constants.CheckFlag(0x9F, 4); //1ADAF 4 for non-boss
        [BingoSquare("Kill Count Ymir, Mother of Fingers")]
        public static bool YmirDead() => constants.CheckFlag(0x2F058, 7);
        [BingoSquare("Kill Queelign in Belurat")]
        public static bool QueelignDead() => constants.CheckFlag(0x17AF13, 3);
        [BingoSquare("Complete 2 Nameless Mausoleums")]
        public static bool MausoleumsCompleted()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x2DD0, 1), //Rakhasa
                (0x2DD9, 3), //Red bear
                (0x16459, 7), //Blackgaol
                (0x15A18, 3), //Dancer
            };
            return constants.CountFlags(bossesData) >= 2;
        }
        [BingoSquare("Clear 2 Gaols")]
        public static bool GaolsCompleted()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x9F, 2), //Onze
                (0x9F, 3), //Labirith
                (0x9F, 4) //Lamenter
            };
            return constants.CountFlags(bossesData) >= 2;
        }
        [BingoSquare("Clear 2 Catacombs")]
        public static bool CatacombsCompleted()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x91, 6), //Jori
                (0x9E, 0), //Death Knight 1
                (0x9E, 1) //Death Knight 2
            };
            return constants.CountFlags(bossesData) >= 2;
        }
        [BingoSquare("Clear two Forges")]
        public static bool ForgesCompleted()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x1835C1, 7),
                (0x183E8B, 7),
                (0x1842F0, 7)
            };
            return constants.CountFlags(bossesData) >= 2;
        }
        [BingoSquare("Kill 4 Remembrance Bosses")]
        public static bool RemembranceBossesDead()
        {
            (int Boss, int Byte)[] bossesData =
            {
                (0x8E, 3), //Dancing lion
                (0x47C, 1), //Rellana
                (0x8F, 3), //Putrescent
                (0x91, 3), //Gaius
                (0x91, 4), //Bayle
                (0x91, 5), // Avatar
                (0x91, 7), //Romina
                (0x90, 3), //Midra
                (0x478, 4), //Metyr
                (0x477, 5), //Messmmer
                (0x8E, 0), //Radahn
            };
            return constants.CountFlags(bossesData) >= 4;
        }
        [BingoSquare("Kill 3 NPC bosses")]
        public static bool NpcBossesDead()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x2DD0, 1), //Rakhasa
                (0x2DD9, 3), //Red bear
                (0x16459, 7), //Lonely man
                (0x15A18, 3), //Dancer
                (0x25689, 7), //Dryleaf Dane(test this)
                (0x9F, 2), //Lamenter
            }; //Leda fight isn't a boss fight
            return constants.CountFlags(bossesData) >= 3;
        }
        [BingoSquare("Kill 3 Dragon bosses")]
        public static bool DragonBossesDead()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x2DD4, 3), //Gravesite ghostflame dragon
                (0x25431, 3), //Cerulean ghostflame dragon
                (0x2531E, 7), //Scadu ghostflame
                (0x489, 5), //Jagged drake peak
                (0x2DCD, 2), //Sennessax
                (0x91, 4), //Bayle
            };
            return constants.CountFlags(bossesData) >= 3;
        }
        [BingoSquare("Kill a Base Game Boss in DLC")]
        public static bool BaseGameBossesDead()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x2DD2, 2), //Marigga
                (0x2DDF, 1), //Tree sentinel 1
                (0x2AC7B, 1), //Tree sentinel 2
                (0x2DE1, 7), //fallingstar beast
                (0x1ABA3, 7), //Deathrite bird
                (0x2DCD, 2), //Sennessax
            };
            return constants.CountFlags(bossesData) >= 1;
        }
        [BingoSquare("Kill one boss of each, Bear / Lion / Hippo")]
        public static bool BearLionHippoDead()
        {
            bool Bear = constants.CheckFlag(0x2DDD, 5) || constants.CheckFlag(0xDB24, 7);
            bool Lion = constants.CheckFlag(0x8E, 3) || constants.CheckFlag(0x174F3, 7);
            bool Hippo = constants.CheckFlag(0x477, 7);
            return Bear && Lion && Hippo;
        }
        [BingoSquare("Kill 3 Bosses with Knight in their name")]
        public static bool KnightBossesDead()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x16459, 7),
                (0x47C, 1),
                (0x2DE1, 2),
                (0x2DE0, 4),
                (0x9E, 1),
                (0x9E, 0),
                (0x8F, 3)
            };
            return constants.CountFlags(bossesData) >= 3;
        }
        [BingoSquare("Kill the Giant Hand in the Finger Ruins Dheo")]
        public static bool GiantHandDead()
        {
            long handAddr = constants.FindAddrById(55510093);
            long handDeadAddr = er.GetOffsets(handAddr, [0x58, 0xC8, 0x24]);
            bool isDead = er.ReadByte(handDeadAddr) == 1;
            return isDead;
        }
        [BingoSquare("Kill 2 Hippos")]
        public static bool HipposDead()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x2ECAE, 3),
                (0x2ECAF, 1),
                (0x1AB64, 3),
                (0x174B3, 5),
                (0x477, 7),
            };
            return constants.CountFlags(bossesData) >= 2;
        }
        [BingoSquare("Kill Bayle while summoning Igon")]
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
                    return constants.CheckFlag(0xC04E6, 7); //check if igon was summoned 
                Thread.Sleep(200);
            }
            return false;
        }
        [BingoSquare("Acquire Level 10 Scadu")]
        public static bool ScaduLvl10()
        {
            long dataMan = er.ReadLong(constants.GetGameDataMan());
            return er.ReadByte(er.GetOffsets(dataMan, [0x08, 0xFC])) >= 10;
        }
        [BingoSquare("Acquire Level 5 Revered Ash")]
        public static bool ReveredAshLvl5()
        {
            long dataMan = er.ReadLong(constants.GetGameDataMan());
            return er.ReadByte(er.GetOffsets(dataMan, [0x08, 0xFD])) >= 5;
        }
        [BingoSquare("Reach Level 85")]
        public static bool PlayerLvl85()
        {
            long dataMan = er.ReadLong(constants.GetGameDataMan());
            return er.ReadByte(er.GetOffsets(dataMan, [0x08, 0x68])) >= 85;
        }
        [BingoSquare("Burn the Sealing Tree")]
        public static bool TreeBurned() => constants.CheckFlag(0x29, 5);
        [BingoSquare("Acquire Euporia")]
        public static bool EuporiaAcquired() => constants.CheckFlag(0x17B214, 5);
        [BingoSquare("Acquire the Golden Braid")]
        public static bool GoldenBraidAcquired() => constants.CheckFlag(0x2F8FD, 1);
        [BingoSquare("Acquire Taylew, the Golem Smith")]
        public static bool TaylewAcquired() => constants.CheckFlag(0x1842F0, 7);
        [BingoSquare("Acquire Velvet St. Trina's Sword")]
        public static bool TrinaSwordAcquired() => constants.CheckFlag(0x17D525, 1);
        [BingoSquare("Acquire Verdigris Discus")]
        public static bool DiscusAcquired() => constants.CheckFlag(0x17A48, 7);
        [BingoSquare("Acquire Commander Gaius's pants")]
        public static bool GayPantsAcquired() => constants.CheckFlag(0x267AC, 3);
        [BingoSquare("Acquire Devonia's Hammer")]
        public static bool DevoniaAcquired() => constants.CheckFlag(0x12B83, 7);
        [BingoSquare("Acquire the Perfumed Oil of Ranah")]
        public static bool RanahOilAcquired() => constants.CheckFlag(0x15B33, 1);
        [BingoSquare("Drain the water in the Church District")]
        public static bool WaterDrainedFromChurch() => constants.CheckFlag(0xF, 3);
        [BingoSquare("Have St. Trina talk to you")]
        public static bool StTrinaTalked() => constants.CheckFlag(0x17D62D, 0);
        [BingoSquare("Heal the wounded Kindred rot")]
        public static bool HealKindredRot() => constants.CheckFlag(0x26B, 0);
        [BingoSquare("Drink Thiollier's Concoction")]
        public static bool ThiolliersDrink()
        {

            long addr = constants.GetPlayerAnim();
            return er.ReadInt(addr) == 17200;
        }
        [BingoSquare("Acquire Both Aspect of the Crucible Incantations")]
        public static bool CrucibleAspectsAcquired() => constants.CheckFlag(0x477, 7) && constants.CheckFlag(0x12B56, 7);
        [BingoSquare("Acquire Death Mask Helm, Winged Serpent Helm, and Salza's Hood")]
        public static bool MaskHelmHoodAcquired() => constants.CheckFlag(0x17C3FB, 4) && constants.CheckFlag(0x17C85F, 0) && constants.CheckFlag(0x17CCC4, 0);
        [BingoSquare("Collect 4 perfumer bottles")]
        public static bool PerfumerBottlesAcquired()
        {
            (int Boss, int Byte)[] bossesData =
{
                (0x1BEB3, 7),
                (0x18289E, 3),
                (0x373CA, 7),
                (0x1FF3B, 7),
                (0x237F, 3),
            };
            return constants.CountFlags(bossesData) >= 4;
        }
        [BingoSquare("Give an Iris of Grace")]
        public static bool IrisOfGraceGiven() => constants.CheckFlag(0x2766, 5) && constants.CheckFlag(0x2763, 1);
        [BingoSquare("Give an Iris of Occultation")]
        public static bool IrisOfOccultationGiven() => constants.CheckFlag(0x2766, 3) && constants.CheckFlag(0x2763, 0);
        [BingoSquare("Acquire Jolan & Anna Summon")]
        public static bool JolanAnnaSummonAcquired() => constants.CheckFlag(0x2F33E, 3);

        [BingoSquare("Use a Transformation")]
        public static bool WasTransformed()
        {
            int ok = constants.GetCurrentTransformation();
            return ok == 1058235609 || ok == 1058032249 || ok == 1057727209;
        }
        [BingoSquare("Visit 5 Miquella Crosses")]
        public static bool Visited5Crosses()
        {
            long eventFlag = er.ReadLong(constants.GetEventFlagMan());
            int count = 0;
            long addr = er.GetOffsets(eventFlag, [0x28, 0x266]);
            count += Convert.ToString(er.ReadByte(addr), 2).Count(c => c == '1');
            (int Boss, int Byte)[] bossesData =
{
                (0x265, 0),
                (0x265, 1),
                (0x267, 5),
                (0x267, 6),
                (0x267, 7),
            };
            count += constants.CountFlags(bossesData);
            return count >= 5;
        }
        [BingoSquare("Acquire the full Gravebird Armor Set")]
        public static bool FullGravebirdAcquired()
        {
            (int Boss, int Byte)[] setData =
            {
                (0x12112, 3),
                (0x20613, 3),
                (0x25EF0, 5),
                (0x17B68E, 3),

            };
            return constants.CountFlags(setData) == 4;
        }
        [BingoSquare("Acquire 2 Painting rewards")]
        public static bool PaintingRewardsAcquired()
        {
            (int Boss, int Byte)[] rewardsData =
            {
                (0x300E, 3),
                (0x300D, 5),
                (0x300C, 7),
            };
            return constants.CountFlags(rewardsData) >= 2;
        }

    }
}
 