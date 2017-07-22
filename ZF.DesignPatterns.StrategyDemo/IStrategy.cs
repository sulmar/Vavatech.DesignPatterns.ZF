using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.StrategyDemo
{
    interface IStrategy
    {
        bool CanDiscount(decimal amount);

        decimal Discount(decimal amount);
    }
}
