using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.TemplateMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Calculator calculator = new NoDiscountCalculator();

            var result = calculator.Calculate(100);

            Console.WriteLine(result);

            calculator = new PercentageDiscountCalculator(0.2m, 100);

            result = calculator.Calculate(200);

            Console.WriteLine(result);
        }
    }
}
