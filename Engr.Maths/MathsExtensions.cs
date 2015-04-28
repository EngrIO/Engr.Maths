using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engr.Maths
{
    public static class MathsExtensions
    {
        public static bool NearlyEquals(this Double x, Double y, Double epsilon = 0.0000001)
        {
            return Math.Abs(x - y) <= Math.Abs(x * .00001);
        }
        public static bool NearlyEquals(this float x, float y, float epsilon = 0.0000001f)
        {
            return Math.Abs(x - y) <= Math.Abs(x * .00001);
        }
    }
}
