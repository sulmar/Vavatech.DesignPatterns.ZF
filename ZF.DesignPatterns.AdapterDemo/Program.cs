﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Wzorzec projektowy Adapter jest wzorcem czynnościowym.

// Jego zadaniem jest dostosowanie niekombatybilnej klasy do naszego kodu 
// Przykład zastosowania: 
// Wywołanie obcej biblioteki bez dostępu do kodu źródłowego

// Adapter składa się z następujących elementów:
// - Target: abstrakcyjny interfejs docelowej klasy
// - Adapter: klasa, która "opakowuje" adaptowaną klasę
// - Adaptee: adoptowana klasa

// Klasa Adapter implementuje abstrakcyjny interfejs Target.
// Adapter przechowuje obiekt docelowej klasy Adaptee i wywołuje konkretne jej metody.
// Dzięki temu z punktu widzenia klienta ukrywamy szczegóły implementacji.


namespace ZF.DesignPatterns.AdapterDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            ITarget device = new DeviceAdapter();
            device.Request();
        }
    }


    // Target
    public interface ITarget
    {
        void Request();
    }

    // Adaptee
    public class ConcreteDevice
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Specific Request");
        }
    }

    // Adapter
    public class DeviceAdapter : ITarget
    {
        private ConcreteDevice m_concreteDevice;

        public DeviceAdapter()
        {
            m_concreteDevice = new ConcreteDevice();
        }

        public void Request()
        {
            m_concreteDevice.SpecificRequest();
        }
    }


}
