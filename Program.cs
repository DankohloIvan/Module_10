using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2

            using (Shop shop = new Shop(
                "CCC",
                "м. Львів, вул. Городоцька, 45",
            StoreType.Shoes))
                {
                    shop.ShowInfo();
                }

            TestMemory(100_000);
            TestMemory(500_000);
            TestMemory(1_000_000);

            Console.WriteLine("Done.");
        }

        static void TestMemory(int size)
        {
            Console.WriteLine($"\n=== Test with {size} objects ===");

            Stopwatch sw = new Stopwatch();

            using (MemoryAllocator allocator = new MemoryAllocator(size))
            {
                sw.Start();
                allocator.Allocate();
                sw.Stop();
                Console.WriteLine($"Allocation time: {sw.ElapsedMilliseconds} ms");

                allocator.ShowGenerations();

                sw.Restart();
                allocator.SimulateActivity();
                allocator.CollectGarbage();
                sw.Stop();
                Console.WriteLine($"GC time: {sw.ElapsedMilliseconds} ms");

                allocator.ShowGenerations();
            }
        }
    }
}
