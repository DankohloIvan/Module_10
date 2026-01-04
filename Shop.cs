using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module_10
{
    internal class Shop : IDisposable
    {
        private bool disposed = false;

        public string Name { get; set; }
        public string Address { get; set; }
        public StoreType Type { get; set; }

        public Shop(string name, string address, StoreType type)
        {
            Name = name;
            Address = address;
            Type = type;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Shop information:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine();
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
                    Console.WriteLine("Disposing managed resources...");
                }

                Console.WriteLine("Shop object disposed.");
                disposed = true;
            }
        }

        ~Shop()
        {
            Dispose(false);
        }
    }

    public enum StoreType
    {
        Grocery,
        Household,
        Clothing,
        Shoes
    }
}
