using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.StateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var device = new Device();

            Console.WriteLine(device.State);

            device.Start();

            Console.WriteLine(device.State);

           // device.Stop();

            Console.WriteLine(device.State);


            Console.ReadKey();

        }
    }
}
