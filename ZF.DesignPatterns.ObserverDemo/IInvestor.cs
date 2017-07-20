using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.ObserverDemo
{

     // Observer
    public interface IInvestor
    {
        void Update(Stock stock);
    }

    // Subject
    public class Stock
    {
        public string Symbol { get; set; }

        #region Price

        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;

                Notify();
            }
            
         }

        #endregion

        private IList<IInvestor> investors = new List<IInvestor>();

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        private void Notify()
        {
            foreach (var investor in investors)
            {
                investor.Update(this);
            }
        }

    }

    // Concrete Observer
    public class Investor : IInvestor
    {
        public string Name { get; set; }

        public void Update(Stock stock)
        {
            Console.WriteLine($"Notified {Name} of {stock.Symbol} change to {stock.Price}");
        }
    }
}
