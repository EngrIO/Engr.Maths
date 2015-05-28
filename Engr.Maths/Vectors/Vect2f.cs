using System;
using System.Collections.Generic;

namespace Engr.Maths.Vectors
{
    public class Vect2f
    {
        /// <summary> X Component </summary>
        public float X { get; private set; }
        /// <summary> Y Component </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Create new Vect2f from floats
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vect2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Create new Vect2f from list of floats
        /// </summary>
        /// <param name="a"></param>
        public Vect2f(IList<float> a)
        {
            if (a.Count != 2) throw new ArgumentException("Array should be float[2]");
            X = a[0];
            Y = a[1];
        }

        /// <summary>
        /// Calculate the length
        /// </summary>
        public float Length
        {
            get
            {

                return (float)Math.Sqrt(LengthSquared);
            }
        }

        /// <summary>
        /// Calculate the square of the length
        /// </summary>
        public float LengthSquared
        {
            get { return X * X + Y * Y; }
        }

        /// <summary>
        /// A zero vector
        /// </summary>
        public static Vect2f Zero
        {
            get { return new Vect2f(0.0f, 0.0f); }
        }

        /// <summary>
        /// A unit vector in the X direction
        /// </summary>
        public static Vect2f UnitX
        {
            get { return new Vect2f(1.0f, 0.0f); }
        }

        /// <summary>
        /// A unit vector in the Y direction
        /// </summary>
        public static Vect2f UnitY
        {
            get { return new Vect2f(0.0f, 1.0f); }
        }

        /// <summary>
        /// Returns a unit Vector
        /// </summary>
        /// <returns>Normalized Vector</returns>
        public Vect2f Normalize()
        {
            var num = 1f / Length;
            return new Vect2f(X * num, Y * num);
        }

        /// <summary>
        /// Calculate the Dot Product
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public float DotProduct(Vect2f v)
        {
            return X * v.X + Y * v.Y;
        }

        /// <summary>
        /// Add a Vector
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vect2f operator +(Vect2f v1, Vect2f v2)
        {
            return new Vect2f(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>
        /// Subtract a Vector
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vect2f operator -(Vect2f v1, Vect2f v2)
        {
            return new Vect2f(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Invert Vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vect2f operator -(Vect2f v)
        {
            return new Vect2f(-v.X, -v.Y);
        }

        /// <summary>
        /// Multiply by float
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vect2f operator *(Vect2f v, float d)
        {
            return new Vect2f(v.X * d, v.Y * d);
        }

        /// <summary>
        /// Multiply by float
        /// </summary>
        /// <param name="d"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vect2f operator *(float d, Vect2f v)
        {
            return v * d;
        }

        /// <summary>
        /// Divide by float
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vect2f operator /(Vect2f v, float d)
        {
            return new Vect2f(v.X / d, v.Y / d);
        }

        /// <summary>
        /// Test for equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vect2f a, Vect2f b)
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
        public static bool operator !=(Vect2f a, Vect2f b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vect2f)obj);
        }

        protected bool Equals(Vect2f other)
        {
            return X.NearlyEquals(other.X) && Y.NearlyEquals(other.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public float[] ToArray()
        {
            return new[] { X, Y };
        }

        public Vect2f Lerp(Vect2f end, float t)
        {
            return (1 - t) * this + t * end;
        }

        public override string ToString()
        {
            return String.Format("Vect2f<{0},{1}>", X, Y);
        }
    }
}