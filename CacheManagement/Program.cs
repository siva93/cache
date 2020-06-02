using System;

namespace CacheManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Apache.Ignite.Core.Ignition.Start();
            Console.WriteLine("Hello World!");
        }
    }
}
