using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public struct Vector
    {
        //Vectors hold positions
        //Only x and y because this is 2d app
        double x;
        double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //Operators
        public static Vector operator +(Vector a) => a;
        public static Vector operator -(Vector a) => new Vector(-a.x, -a.y);
        public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
        public static Vector operator *(Vector a, Vector b) => new Vector(a.x * b.x, a.y * b.y);
        public static Vector operator /(Vector a, Vector b) => new Vector(a.x / b.x != 0 ? b.x : throw new DivideByZeroException(), a.y / b.y != 0 ? b.y : throw new DivideByZeroException());
        public static Vector operator %(Vector a, Vector b) => new Vector(a.x % b.x, a.y % b.y);
    }
}
