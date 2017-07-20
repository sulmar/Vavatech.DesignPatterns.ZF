using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.SOLID.ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new Machine(new Drill(), new Welder());

            machine.Run();


        }
    }
}
