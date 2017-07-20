using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.SOLID.ISP
{
    class Drill : IDrill
    {
        public void SetPosition(Position position)
        {
            Console.WriteLine($"PLC Ustawienie na pozycji {position}");
        }

        private void StartEngine()
        {
            Console.WriteLine("Uruchomienie silnika");
        }

        public void Start()
        {
            StartEngine();

            Thread.Sleep(1000);

            Console.WriteLine("PLC Uruchomienie wiertarki");
        }

        public void Stop()
        {
            Console.WriteLine("PLC Zatrzymanie wiertarki");
        }
    }
}
