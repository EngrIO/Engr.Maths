using System;
using System.Linq;

namespace Engr.Maths.Vectors
{
    public class Vect
    {
        private readonly double[] _components;

        public Vect(params double[] components)
        {
            _components = components;
        }

        public double this[int index]
        {
            get
            {
                return _components[index];
            }
        }

        /// <summary>
        /// Calculate the length
        /// </summary>
        public double Length
        {
            get { return Math.Sqrt(LengthSquared); }
        }
        /// <summary>
        /// Calculate the square of the length
        /// </summary>
        public double LengthSquared
        {
            get
            {
                return _components.Sum(d => d * d);
            }
        }
    }
}