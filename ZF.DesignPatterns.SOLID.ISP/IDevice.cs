using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.SOLID.ISP
{
    interface IDevice
    {
        void Start();

        void Stop();
    }

    interface IPositionable
    {
        void SetPosition(Position position);
    }

    abstract class Position
    {
        public abstract string Display { get; }
    }

    class Position3D : Position2D
    {
        public float Z { get; set; }

        public override string Display => $"X: {this.X} - Y: {this.Y} - Z: {this.Z}";
    }

    class Position2D: Position
    {
        public float X { get; set; }

        public float Y { get; set; }

        public override string Display => $"X: {this.X} - Y: {this.Y}";



        public override string ToString() => Display;
    }

    interface IDrill : IDevice, IPositionable
    {
      
    }

    interface IWelder : IDevice, IPositionable
    {
        void SetCurrent(float current);

  
    }
}
