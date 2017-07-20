using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.Instance;


            Singleton singleton2 = Singleton.Instance;

            Singleton singleton3 = Singleton.Instance;

            if (singleton1 == singleton3)
            {
                Console.WriteLine("Identyczne");
            }
            else
            {
                Console.WriteLine("Różne");
            }
        }
    }
}
