using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.StateDemo
{
    class Device
    {
        private readonly StateMachine<State, Trigger> machine;

        private System.Timers.Timer timer;

        private const int timeout = 5; // in seconds

        public Device()
        {
            machine = new StateMachine<State, Trigger>(State.Off);

            machine.Configure(State.Off)
                .Permit(Trigger.Start, State.On)
                .OnEntry(Started);

            machine.Configure(State.On)
                .Permit(Trigger.Stop, State.Off)
                .Permit(Trigger.ElapsedTime, State.Off)
                .OnEntry(() => timer.Start());

            // http://www.webgraphviz.com/
            Console.WriteLine(machine.ToDotGraph());


            timer = new System.Timers.Timer(TimeSpan.FromSeconds(timeout).TotalMilliseconds);
            timer.AutoReset = false;
            timer.Elapsed += (sender, args) => machine.Fire(Trigger.ElapsedTime);
        }

        private void Started()
        {
            Console.WriteLine("Wyłączone!");
        }

        public void Start()
        {
            machine.Fire(Trigger.Start);
        }

        public void Stop()
        {
            machine.Fire(Trigger.Stop);
        }

        public State State
        {
            get
            {
                return machine.State;
            }
        }
    }

    public enum State
    {
        On,

        Off
    }

    public enum Trigger
    {
        Start,

        Stop,

        ElapsedTime
      
    }
}
