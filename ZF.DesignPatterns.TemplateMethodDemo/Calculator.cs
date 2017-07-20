using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.TemplateMethodDemo
{

    public abstract class Calculator
    {

        public abstract bool CanDiscount(decimal amount);

        public abstract decimal Discount(decimal amount);

        public decimal Calculate(decimal amount)
        {
            if (CanDiscount(amount))
            {
                amount = amount - Discount(amount);
            }

            return amount;
        }
    }

    public class NoDiscountCalculator : Calculator
    {
        public override bool CanDiscount(decimal amount)
        {
            return false;
        }

        public override decimal Discount(decimal amount)
        {
            throw new InvalidOperationException();
        }
    }

    public class PercentageDiscountCalculator : Calculator
    {
        private readonly decimal minimumAmount;
        private readonly decimal ratio;

        public PercentageDiscountCalculator(decimal ratio, decimal minimumAmount)
        {
            this.ratio = ratio;
            this.minimumAmount = minimumAmount;
        }

        public override bool CanDiscount(decimal amount)
        {
            return amount > minimumAmount;
        }

        public override decimal Discount(decimal amount)
        {
            return ratio * amount;
        }
    }


    public class FixAmontDiscountCalculator : Calculator
    {
        private readonly decimal minimumAmount;
        private readonly decimal discountAmount;

        public FixAmontDiscountCalculator(decimal minimumAmount, decimal discountAmount)
        {
            this.minimumAmount = minimumAmount;
            this.discountAmount = discountAmount;
        }

        public override bool CanDiscount(decimal amount)
        {
            return amount > minimumAmount;
        }

        public override decimal Discount(decimal amount)
        {
            return discountAmount;
        }
    }
}
