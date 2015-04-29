using System;
using System.Collections.Generic;

namespace Engr.Maths.Vectors
{
    /// <summary>
    /// A float precision vector 3 implementation
    /// </summary>
    public class Vect3f
    {
        /// <summary> X Component </summary>
        public float X { get; private set; }
        /// <summary> Y Component </summary>
        public float Y { get; private set; }
        /// <summary> Z Component </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Create new Vect3f from floats
        /// </summary>
        /// <param name="x">X Component</param>
        /// <param name="y">Y Component</param>
        /// <param name="z">Z Component</param>
        public Vect3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Create new Vect3f from list of floats
        /// </summary>
        /// <param name="a"></param>
        public Vect3f(IList<float> a)
        {
            if (a.Count != 3) throw new ArgumentException("Array should be float[3]");
            X = a[0];
            Y = a[1];
            Z = a[2];
        }

        /// <summary>
        /// Calculate the length
        /// </summary>
        public float Length
        {
            get { return (float)Math.Sqrt(LengthSquared); }
        }
        /// <summary>
        /// Calculate the square of the length
        /// </summary>
        public float LengthSquared
        {
            get { return X * X + Y * Y + Z * Z; }
        }

        /// <summary>
        /// A zero vector
        /// </summary>
        public static Vect3f Zero
        {
            get { return new Vect3f(0.0f, 0.0f, 0.0f); }
        }

        /// <summary>
        /// A unit vector in the X direction
        /// </summary>
        public static Vect3f UnitX
        {
            get { return new Vect3f(1.0f, 0.0f, 0.0f); }
        }

        /// <summary>
        /// A unit vector in the Y direction
        /// </summary>
        public static Vect3f UnitY
        {
            get { return new Vect3f(0.0f, 1.0f, 0.0f); }
        }

        /// <summary>
        /// A unit vector in the Z direction
        /// </summary>
        public static Vect3f UnitZ
        {
            get { return new Vect3f(0.0f, 0.0f, 1.0f); }
        }

        /// <summary>
        /// Returns a unit Vector
        /// </summary>
        /// <returns>Normalized Vector</returns>
        public Vect3f Normalized()
        {
            var num = 1f / Length;
            return new Vect3f(X * num, Y * num, Z * num);
        }

        /// <summary>
        /// Calculate the Cross Product
        /// </summary>
        /// <param name="b">Other Vector</param>
        /// <returns>Cross Product</returns>
        public Vect3f CrossProduct(Vect3f b)
        {
            return new Vect3f(Y * b.Z - Z * b.Y, Z * b.X - X * b.Z, X * b.Y - Y * b.X);
        }

        /// <summary>
        /// Calculate the Dot Product
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public float DotProduct(Vect3f v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        /// <summary>
        /// Add a Vector
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vect3f operator +(Vect3f v1, Vect3f v2)
        {
            return new Vect3f(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Subtract a Vector
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vect3f operator -(Vect3f v1, Vect3f v2)
        {
            return new Vect3f(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>
        /// Invert Vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vect3f operator -(Vect3f v)
        {
            return new Vect3f(-v.X, -v.Y, -v.Z);
        }

        /// <summary>
        /// Multiply by float
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vect3f operator *(Vect3f v, float d)
        {
            return new Vect3f(v.X * d, v.Y * d, v.Z * d);
        }

        /// <summary>
        /// Multiply by float
        /// </summary>
        /// <param name="d"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vect3f operator *(float d, Vect3f v)
        {
            return v * d;
        }

        /// <summary>
        /// Divide by float
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vect3f operator /(Vect3f v, float d)
        {
            return new Vect3f(v.X / d, v.Y / d, v.Z / d);
        }

        /// <summary>
        /// Test for equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vect3f a, Vect3f b)
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
        public static bool operator !=(Vect3f a, Vect3f b)
        {
            return !(a == b);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vect3f)obj);
        }

        protected bool Equals(Vect3f other)
        {
            return X.NearlyEquals(other.X) && Y.NearlyEquals(other.Y) && Z.NearlyEquals(other.Z);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public float[] ToArray()
        {
            return new[] { X, Y, Z };
        }

        public Vect3f Lerp(Vect3f end, float t)
        {
            return (1 - t) * this + t * end;
        }

        public override string ToString()
        {
            return String.Format("Vect3f<{0},{1},{2}>", X, Y, Z);
        }
    }
}