using System;
using System.Collections.Generic;

namespace Engr.Maths.Vectors
{
    public class Vect4f
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public float W { get; private set; }

        public Vect4f(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        public Vect4f(IList<float> a)
        {
            if (a.Count != 4) throw new ArgumentException("Array should be float[4]");
            X = a[0];
            Y = a[1];
            Z = a[2];
            W = a[3];
        }

        public float Length
        {
            get { return (float) Math.Sqrt(LengthSquared); }
        }

        public float LengthSquared
        {
            get { return X * X + Y * Y + Z * Z + W * W; }
        }

        public Vect4f Normalized()
        {
            var num = 1f / Length;
            return new Vect4f(X * num, Y * num, Z * num, W * num);
        }

        public static Vect4f Zero
        {
            get { return new Vect4f(0.0f, 0.0f, 0.0f, 0.0f); }
        }
        public static Vect4f UnitX
        {
            get { return new Vect4f(1.0f, 0.0f, 0.0f, 0.0f); }
        }

        public static Vect4f UnitY
        {
            get { return new Vect4f(0.0f, 1.0f, 0.0f, 0.0f); }
        }

        public static Vect4f UnitZ
        {
            get { return new Vect4f(0.0f, 0.0f, 1.0f, 0.0f); }
        }

        public static Vect4f UnitW
        {
            get { return new Vect4f(0.0f, 0.0f, 0.0f, 1.0f); }
        }

        public float DotProduct(Vect4f v)
        {
            return X * v.X + Y * v.Y + Z * v.Z + W * v.W;
        }

        public Vect4f ExteriorProduct(Vect4f v)
        {
            throw new NotImplementedException();
        }

        public static Vect4f operator +(Vect4f v1, Vect4f v2)
        {
            return new Vect4f(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
        }

        public static Vect4f operator -(Vect4f v1, Vect4f v2)
        {
            return new Vect4f(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z, v1.W - v2.W);
        }
        public static Vect4f operator -(Vect4f v)
        {
            return new Vect4f(-v.X, -v.Y, -v.Z, -v.W);
        }

        public static Vect4f operator *(Vect4f v, float d)
        {
            return new Vect4f(v.X * d, v.Y * d, v.Z * d, v.W * d);
        }

        public static Vect4f operator *(float d, Vect4f v)
        {
            return v * d;
        }

        public static Vect4f operator /(Vect4f v, float d)
        {
            return new Vect4f(v.X / d, v.Y / d, v.Z / d, v.W / d);
        }
        /// <summary>
        /// Test for equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vect4f a, Vect4f b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Test for not equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vect4f a, Vect4f b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vect4f)obj);
        }

        protected bool Equals(Vect4f other)
        {
            return X.NearlyEquals(other.X) && Y.NearlyEquals(other.Y) && Z.NearlyEquals(other.Z) && W.NearlyEquals(other.W);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }


        public Vect4f Lerp(Vect4f end, float t)
        {
            return (1 - t) * this + t * end;
        }

        public override string ToString()
        {
            return String.Format("Vector4({0},{1},{2},{3})", X, Y, Z, W);
        }

        public float[] ToArray()
        {
            return new[] { X, Y, Z, W };
        }

    }
}