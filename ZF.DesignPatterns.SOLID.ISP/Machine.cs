using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.SOLID.ISP
{
    class Machine
    {
        private readonly IDrill drill;
        private readonly IWelder welder;

        public Machine(IDrill drill, IWelder welder)
        {
            this.drill = drill;
            this.welder = welder;
        }

        public void Run()
        {
            Drill1();

            Weld1();

            // Drill2();

            Save();
        }

        private void Save()
        {
            Console.WriteLine("Zapisanie do bazy danych");
        }

        private void Weld1()
        {
           // IDevice welder = new Welder();
            welder.Start();

            Thread.Sleep(1000);

            Console.WriteLine("PLC Ustawiemie spawarki w pozycji X2 - Y2");
            Console.WriteLine("PLC Zatrzymanie spawarki");
        }

        private void Drill1()
        {
            // var drill = new Drill();

            Position2D position = new Position3D { X = 20, Y = 10 };

            drill.SetPosition(position);

            // drill.StartEngine();

           //  Thread.Sleep(1000);

            drill.Start();


            drill.Stop();
        }
    }
}
