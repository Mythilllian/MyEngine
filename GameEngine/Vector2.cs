using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public struct Vector2
    {
        //Vectors hold positions and sizes
        public int x;
        public int y;

        public static readonly Vector2 Zero = new Vector2() { x = 0 };
        public static readonly Vector2 One = new Vector2() { x = 1 };


        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Operators
        public static Vector2 operator +(Vector2 a) => a;
        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x != 0 ? b.x : throw new DivideByZeroException(), a.y / b.y != 0 ? b.y : throw new DivideByZeroException());
        public static Vector2 operator %(Vector2 a, Vector2 b) => new Vector2(a.x % b.x, a.y % b.y);
    }
}
