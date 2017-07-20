using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var investor1 = new Investor { Name = "Marcin Sulecki" };
            var investor2 = new Investor { Name = "Rafał" };
            var investor3 = new Investor { Name = "Łukasz" };

            var stock = new Stock { Symbol = "MSFT", Price = 120.01m };
            stock.Attach(investor1);
            stock.Attach(investor3);

            stock.Price = 130;
            stock.Price = 134;
            stock.Price = 129;

            stock.Detach(investor3);

            stock.Price = 127;
            stock.Price = 120;




        }
    }
}
