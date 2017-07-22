using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.StrategyDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            IStrategy strategy = new PercentageDiscountStrategy(50, 0.8m);

            var calculator = new Calculator(strategy);

            var result = calculator.Calculate(100);

            Console.WriteLine($"{result}");
        }
    }
}
