using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_10
{
    internal class MemoryAllocator : IDisposable
    {
        private int[][] data;
        private bool disposed = false;

        public MemoryAllocator(int size)
        {
            data = new int[size][];
        }

        public void Allocate()
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new int[10];
            }
        }

        public void SimulateActivity()
        {
            for (int i = 0; i < data.Length; i += 2)
            {
                data[i] = null;
            }
        }

        public void ShowGenerations()
        {
            int count = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null && count < 5)
                {
                    Console.WriteLine($"Object {i} generation: {GC.GetGeneration(data[i])}");
                    count++;
                }
            }
        }

        public void CollectGarbage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    data = null;
                    Console.WriteLine("Managed resources disposed.");
                }

                disposed = true;
            }
        }

        ~MemoryAllocator()
        {
            Console.WriteLine("Finalizer called.");
            Dispose(false);
        }
    }
}
