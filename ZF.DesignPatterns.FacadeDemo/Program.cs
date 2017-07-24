using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.FacadeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWashMachine washmachine = new WashMachine(
                new EngineController(),
                new HeaterController(),
                new PumpController());

            washmachine.Start();

            washmachine.Stop();
        }
    }

    // Facade

    interface IWashMachine
    {
        void Start();

        void Stop();

    }


    // Subsystem A
    public interface IEngineController
    {
        bool Running { get; }
        void Start();
        void Stop();

    }

    // Subsystem B
    public interface IHeaterController
    {
        int Temperature { get; }
        void On();
        void Off();

    }

    // Subsystem C
    public interface IPumpController
    {
        void Start();
        void Stop();
    }


    public class HeaterController : IHeaterController
    {
        public int Temperature { get; private set; }

        public void On()
        {
            Console.WriteLine("Heater on");
        }

        public void Off()
        {
            Console.WriteLine("Heater off");
        }

    }


    public class PumpController : IPumpController
    {
        public void Start()
        {
            Console.WriteLine("Pump started");
        }

        public void Stop()
        {
            Console.WriteLine("Pump stopped");
        }

    }


    public class EngineController : IEngineController
    {
        public bool Running { get; private set; }

        public void Start()
        {
            Running = true;
            Console.WriteLine("Engine started");
        }

        public void Stop()
        {
            Running = false;
            Console.WriteLine("Engine stopped");
        }
    }

    class WashMachine : IWashMachine
    {
        private readonly IEngineController _engineController;
        private readonly IHeaterController _heaterController;
        private readonly IPumpController _pumpController;

        public WashMachine(
            IEngineController engineController,
            IHeaterController heaterController,
            IPumpController pumpController)
        {
            _engineController = engineController;
            _heaterController = heaterController;
            _pumpController = pumpController;
        }

        public void Start()
        {
            _pumpController.Start();
            _engineController.Start();
            _heaterController.On();
            _pumpController.Stop();

        }

        public void Stop()
        {
            _engineController.Stop();
            _heaterController.Off();
            _pumpController.Stop();
        }
    }
}