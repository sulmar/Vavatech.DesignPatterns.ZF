using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.PrototypeDemo
{
    class Invoice : ICloneable
    {
        public string Number { get; set; }

        public DateTime CreateDate { get; set; }

        public Customer Customer { get; set; }

        public DateTime DeliveryDate { get; set; }

        public object Clone()
        {
            //var copyInvoice = new Invoice
            //{
            //    Number = this.Number,
            //    CreateDate = DateTime.Now,
            //    Customer = this.Customer
            //};

            var copyInvoice = this.MemberwiseClone();

            return copyInvoice;
        }

    }

    class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

  

