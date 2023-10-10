using System;

namespace GameEngine.Engine
{
    public struct Vector2
    {
        //Vectors hold positions and sizes
        public float x;
        public float y;

        public static readonly Vector2 Zero = new Vector2() { x = 0 };
        public static readonly Vector2 One = new Vector2() { x = 1 };


        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        //Static Functions
        /// <summary>
        /// Finds a Vector2 in between a and b in the position of t
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t">Position where the interpolation occurs</param>
        /// <returns></returns>
        public static Vector2 Interpolate(Vector2 a, Vector2 b, float t = 0.5f)
        {
            if(t < 0 || t > 1) { throw new ArgumentException(); }

            Vector2 lerp = new Vector2(a.y + ((t * a.x) * (b.y - a.y)) / (b.x - a.x));
            return new Vector2(a.x + ((a.x - b.x) * t), a.y + ((a.y - b.y) * t));
        }

        //Operators
        public static Vector2 operator +(Vector2 a) => a;
        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2((int)(a.x * b), (int)(a.y * b));
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x != 0 ? b.x : throw new DivideByZeroException(), a.y / b.y != 0 ? b.y : throw new DivideByZeroException());
        public static Vector2 operator /(Vector2 a, float b) => 
            b != 0 ? new Vector2((int)(a.x / b), (int)(a.y / b)) : throw new DivideByZeroException();
        public static Vector2 operator %(Vector2 a, Vector2 b) => new Vector2(a.x % b.x, a.y % b.y);
        public static bool operator ==(Vector2 a, Vector2 b) => a.Equals(b);
        public static bool operator !=(Vector2 a, Vector2 b) => !a.Equals(b);

        public override bool Equals(object obj)
        {
            return obj is Vector2 vector &&
                   x == vector.x &&
                   y == vector.y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }
    }
}
