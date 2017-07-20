using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.SOLID.ISP
{
    class Welder : IWelder
    {
        public void SetPosition(Position position)
        {
            Init();

            // Park();

            Console.WriteLine($"PLC Ustawiemie spawarki w pozycji {position} ");
        }

        private static void Park()
        {
            Console.WriteLine("PLC51");
            Console.WriteLine("PLC62");
            Console.WriteLine("PLC73");
        }

        private static void Init()
        {
            Console.WriteLine("PLC1");
            Console.WriteLine("PLC2");
            Console.WriteLine("PLC3");
        }

        public void SetCurrent(float current)
        {
            Console.WriteLine($"Ustawienie prądu {current} A");
        }

        public void Start()
        {
            Console.WriteLine("PLC Uruchomienie spawarki");
        }

        public void Stop()
        {
            //SetPositon(0, 0);


            // TODO: zatrzymanie silnika

            // throw new NotImplementedException();
        }
    }
}
