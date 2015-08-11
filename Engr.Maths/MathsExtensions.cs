using System;
using Engr.Maths.Vectors;

namespace Engr.Maths
{
    public static class MathsHelper
    {
        public static double Map(this double x, double inMin, double inMax, double outMin, double outMax)
        {
            return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static bool NearlyEquals(this Double x, Double y, Double epsilon = 0.0000001)
        {
            return Math.Abs(x - y) <= Math.Abs(x * .00001);
        }
        public static bool NearlyEquals(this float x, float y, float epsilon = 0.0000001f)
        {
            return Math.Abs(x - y) <= Math.Abs(x * .00001);
        }

        public static bool NearlyLessThanOrEquals(this Double x, Double y, Double epsilon = 0.0000001)
        {
            return x <= y || x.NearlyEquals(y, epsilon);
        }

        public static bool NearlyGreaterThanOrEquals(this Double x, Double y, Double epsilon = 0.0000001)
        {
            return x >= y || x.NearlyEquals(y, epsilon);
        }

        public static bool NearlyLessThanOrEquals(this float x, float y, float epsilon = 0.0000001f)
        {
            return x <= y || x.NearlyEquals(y, epsilon);
        }

        public static bool NearlyGreaterThanOrEquals(this float x, float y, float epsilon = 0.0000001f)
        {
            return x >= y || x.NearlyEquals(y, epsilon);
        }

        public static dynamic Swizzle(this Vect2 v)
        {
            var s = new Swizzle<double>();
            s.Add('X', v.X);
            s.Add('Y', v.Y);
            return s;
        }

        public static dynamic Swizzle(this Vect2f v)
        {
            var s = new Swizzle<float>();
            s.Add('X', v.X);
            s.Add('Y', v.Y);
            return s;
        }

        public static dynamic Swizzle(this Vect3 v)
        {
            var s = new Swizzle<double>();
            s.Add('X', v.X);
            s.Add('Y', v.Y);
            s.Add('Z', v.Z);
            return s;
        }

        public static dynamic Swizzle(this Vect3f v)
        {
            var s = new Swizzle<float>();
            s.Add('X', v.X);
            s.Add('Y', v.Y);
            s.Add('Z', v.Z);
            return s;
        }

        public static dynamic Swizzle(this Vect4 v)
        {
            var s = new Swizzle<double>();
            s.Add('X', v.X);
            s.Add('Y', v.Y);
            s.Add('Z', v.Z);
            s.Add('W', v.W);
            return s;
        }

        public static dynamic Swizzle(this Vect4f v)
        {
            var s = new Swizzle<float>();
            s.Add('X', v.X);
            s.Add('Y', v.Y);
            s.Add('Z', v.Z);
            s.Add('W', v.W);
            return s;
        }
    }
}
