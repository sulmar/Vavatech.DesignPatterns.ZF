using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.FluentApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = Order.Create();

            order.Calculate();

            order.Send();

          //  Order.Create().Calculate().Send();
        }
    }

    class Order
    {
        public decimal Amount { get; set; }

        public static Order Create()
        {
            return new Order();
        }

        public void Calculate()
        {
            this.Amount = 199;
        }

        public void Send()
        {
            Console.WriteLine($"Send order {this.Amount}");
        }

    }
}
