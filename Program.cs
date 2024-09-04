using System.Diagnostics;
using System.Text.Json;
namespace Elden_Ring_Auto_Bingo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ERMemoryReader er = new ERMemoryReader();
            ERConstants constants = new ERConstants(er);
            Console.WriteLine(BingoSquares.IsFiaChampionsDead());

            //Console.WriteLine(BingoSquares.IsLeonineDead());
            //Console.WriteLine(BingoSquares.IsRedWolfDead());

            //long eventflag = er.ReadLong(constants.GetEventflagman());
            //long yes = er.GetOffsets(eventflag, [0x28, 0x15814C]);

            //Console.WriteLine(er.ReadBytes(yes, 1)[0] & 128);
            //long onbossaddr = er.GetOffsets(er.ERProcess.MainModule.BaseAddress, [0x03D5DF58, 0xCC]);

            //int curr_boss = er.ReadInt(onbossaddr);
            //while (true)
            //{

            //    curr_boss = er.ReadInt(onbossaddr);

            //    if (curr_boss == 0)
            //    {
            //        Console.WriteLine("No boss here");
            //        Thread.Sleep(5000);
            //    }
            //    else
            //    {
            //        long enemy_addr = constants.FindAddrById(curr_boss);
            //        Console.WriteLine(FindGameNameOrCodename("C:\\Users\\reiri\\Documents\\GitHub\\Elden-autobingo\\output.json", curr_boss) + " || ID: " + curr_boss);
            //        int count = 0;
            //        int current_animation = 0;
            //        while (curr_boss != 0)
            //        {
            //            current_animation = er.ReadInt(er.GetOffsets(enemy_addr, [0x190, 0x18, 0x40]));
            //            if (current_animation == 2008500 || current_animation == 2020015)
            //            {
            //                Console.WriteLine("Parry");
            //                count += 1;
            //                Console.WriteLine("Current parries: " + count);
            //                while (current_animation == 2008500 || current_animation == 2020015)
            //                {
            //                    current_animation = er.ReadInt(er.GetOffsets(enemy_addr, [0x190, 0x18, 0x40]));
            //                    Thread.Sleep(100);
            //                }
            //                Console.WriteLine("Parry animation done");

            //            }
            //            // System.Console.WriteLine(current_animation);
            //            Thread.Sleep(100);
            //            curr_boss = er.ReadInt(onbossaddr);
            //        }
            //        Thread.Sleep(1000);
            //    }
            //}
        }
        //// 2008500  2020015
        public static string FindGameNameOrCodename(string filePath, int searchNumber)
        {
            if (searchNumber >= 10000000)
            {
                searchNumber /= 10000;
            }

            var jsonData = File.ReadAllText(filePath);
            var jsonArray = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonData);

            var result = jsonArray.FirstOrDefault(x => x["id"].ToString() == searchNumber.ToString());
            if (result != null)
            {
                var gamename = result["gamename"]?.ToString();
                return !string.IsNullOrEmpty(gamename) ? gamename : result["codename"]?.ToString();
            }

            return "ID not found";
        }

        //static int get_chr_count(IntPtr er_addr, Process er_process)
        //{
        //    long worldchrman = CMem.ReadLongLong(er_addr, get_worldchrman(er_addr, er_process));
        //    long begin = CMem.ReadLongLong(er_addr, worldchrman + 0x1F1B8);
        //    long end = CMem.ReadLongLong(er_addr, worldchrman + 0x1F1C0);
        //    int chr_count = (int)(end - begin) / 8;
        //    return chr_count;
        //}
        //static long get_chr_set(IntPtr er_addr, Process er_process)
        //{
        //    long worldchrman = CMem.ReadLongLong(er_addr, get_worldchrman(er_addr, er_process));
        //    long chrset = CMem.ReadLongLong(er_addr, worldchrman + 0x1F1B8);
        //    return chrset;
        //}

        //static long test(IntPtr er_addr, Process er_process)
        //{
        //    int chr_count = constants.get_chr_count();
        //    long enemyaddr = 0;
        //    long chrset = get_chr_set(er_addr, er_process);
        //    for (int i = 0; i < chr_count; i++)
        //    {
        //        enemyaddr = CMem.ReadLongLong(er_addr, chrset + i * 0x10);
        //        int paramid = CMem.ReadInt(er_addr, enemyaddr + 0x60);
        //        if (paramid == 21300014)
        //        {
        //            System.Console.WriteLine(enemyaddr.ToString("x8"));
        //            return enemyaddr;
        //        }
        //    }
        //    return 0;
        //}
        //static List<long> ok(IntPtr er)
        //{
        //    long player_coords = 0x7ff4272dff50;
        //    float player_x = CMem.ReadFloat(er, player_coords);
        //    float player_y = CMem.ReadFloat(er, player_coords + 4);
        //    float player_z = CMem.ReadFloat(er, player_coords + 8);
        //    int chr_count = 0x21A;
        //    long chrset = 0x7ff422309780;
        //    List<long> result = new List<long>();
        //    for (int i = 0; i < chr_count; i++)
        //    {
        //        long enemy_addr = CMem.ReadLongLong(er, chrset + i * 0x10);
        //        long alliance = CMem.GetOffsets(er, enemy_addr, [0x6C]);
        //        byte[] alliance_bytes = CMem.ReadBytes(er, alliance, 1);
        //        if (alliance_bytes[0] == 0x06 && get_distance(er, enemy_addr, player_x, player_y, player_z) <= 200)
        //        {
        //            result.Add(enemy_addr);
        //        }
        //    }
        //    return result;
        //}
        //static double get_distance(IntPtr er, long enemy_coords, float player_x, float player_y, float player_z)
        //{
        //    long coords = CMem.GetOffsets(er, enemy_coords, [0x190, 0x68, 0x0]) + 0x70;
        //    float x = CMem.ReadFloat(er, coords);
        //    float y = CMem.ReadFloat(er, coords + 0x04);
        //    float z = CMem.ReadFloat(er, coords + 0x08);
        //    double distance = Math.Sqrt(Math.Pow(player_x - x, 2) + Math.Pow(player_y - y, 2) + Math.Pow(player_z - z, 2));
        //    return distance;
        //}
        //static void Slow(IntPtr er)
        //{
        //    List<long> addr_list = ok(er);
        //    foreach (long addr in addr_list)
        //    {
        //        long speed = CMem.GetOffsets(er, addr, [0x190, 0x28, 0x17C8]);
        //    }
        //}
        //static async Task SlowAsync(IntPtr er)
        //{
        //    List<long> addr_list = ok(er);
        //    List<Task> tasks = new List<Task>();

        //    foreach (long addr in addr_list)
        //    {
        //        tasks.Add(Task.Run(() =>
        //        {
        //            long speed = CMem.GetOffsets(er, addr, [0x190, 0x28, 0x17C8]);
        //        }));
        //    }

        //    await Task.WhenAll(tasks);
        //}
    }
}
