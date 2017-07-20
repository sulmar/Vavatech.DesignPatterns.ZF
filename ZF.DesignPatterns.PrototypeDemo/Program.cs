using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.PrototypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var invoice1 = new Invoice
            {
                Number = "FV001/2017",
                CreateDate = DateTime.Now,
                Customer = new Customer
                {
                    FirstName = "Marcin",
                    LastName = "Sulecki",
                    
                },
                DeliveryDate = DateTime.Today.AddDays(7)
            };

            Invoice invoice2 = (Invoice) invoice1.Clone();

            //var invoice2 = new Invoice
            //{
            //    Number = invoice1.Number,
            //    CreateDate = DateTime.Now,
            //    Customer = invoice1.Customer
            //};

        }
    }
}
