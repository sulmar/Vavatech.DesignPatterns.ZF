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
            //var order = Order.Create();

            //order.Calculate();

            //order.Send();

            var product1 = new Product { Name = "Książka 1", Price = 10 };
            var product2 = new Product { Name = "Książka 2", Price = 110 };


            Order
                 .Create()
                 .AddItem(Item.Create(product1, 10))
                 .AddItem(Item.Create(product2, 2))
                 .CanDiscount()
                 .Calculate()
                 .Send();
        }
    }

    class Order
    {
        public IList<Item> Items { get; set; } = new List<Item>();

        public decimal Amount { get; set; }

        private bool isDiscount;

        public static Order Create()
        {
            return new Order();
        }

        public Order AddItem(Item item)
        {
            this.Items.Add(item);

            return this;
        }

        public Order CanDiscount()
        {
            this.isDiscount = true;

            return this;
        }

        public Order Calculate()
        {
            if (this.isDiscount)
            {
                this.Amount = 100;
            }
            else
                this.Amount = 199;

            return this;
        }

        public void Send()
        {
            Console.WriteLine($"Send order {this.Amount}");
        }

    }

    class Item
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public static Item Create(Product product, int quantity)
        {
            return new Item { Product = product, Quantity = quantity }
        }

    }

    class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
