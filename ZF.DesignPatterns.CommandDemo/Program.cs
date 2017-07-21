using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.CommandDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order { OrderId = 1, Amount = 100 };

            ICommand command = new SendCommand(order);

            if (command.CanExecute)
            {
                command.Execute();
            }
        }
    }

    interface ICommand
    {
        void Execute();

        bool CanExecute { get; }
    }

    class SendCommand : ICommand
    {
        private readonly Order order;

        public SendCommand(Order order)
        {
            this.order = order;
        }

        public bool CanExecute
        {
            get

            {
                return !string.IsNullOrEmpty(order.To);
            }
        }

        public void Execute()
        {
            Console.WriteLine($"Send order to {order.To} amount {order.Amount}");
        }
    }


    public class Order
    {
        public int OrderId { get; set; }

        public string To { get; set; }

        public decimal Amount { get; set; }
    }



}
