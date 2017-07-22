using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.StrategyDemo
{
    class Calculator
    {
        private readonly IStrategy currentStrategy;

        public Calculator(IStrategy strategy)
        {
            this.currentStrategy = strategy;
        }

        public decimal Calculate(decimal amount)
        {
            if (currentStrategy.CanDiscount(amount))
            {
                amount = amount - currentStrategy.Discount(amount);
            }

            return amount;
        }
    }

    public class NoDiscountStrategy : IStrategy
    {
        public bool CanDiscount(decimal amount)
        {
            return false;
        }

        public decimal Discount(decimal amount)
        {
            throw new InvalidOperationException();
        }
    }

    public class PercentageDiscountStrategy : IStrategy
    {
        private readonly decimal minimumAmount;
        private readonly decimal ratio;

        public PercentageDiscountStrategy(decimal minimumAmount, decimal ratio)
        {
            this.minimumAmount = minimumAmount;
            this.ratio = ratio;
        }

        public bool CanDiscount(decimal amount)
        {
            return amount > minimumAmount;
        }

        public decimal Discount(decimal amount)
        {
            return amount * ratio;
        }
    }
}
