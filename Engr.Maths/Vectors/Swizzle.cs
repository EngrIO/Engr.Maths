using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Engr.Maths.Vectors
{
    public class Swizzle<T> : DynamicObject
    {
        private readonly Dictionary<char, T> _members = new Dictionary<char, T>();

        public void Add(char c, T val)
        {
            _members.Add(c, val);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var array = binder.Name.Select(c =>
            {
                T value;
                if (_members.TryGetValue(c, out value))
                {
                    return value;
                }
                throw new Exception(String.Format("Member Does Not Exist: {0}", c));
            }).ToArray();
            var type = typeof(T);

            if (binder.Name.Length == 1)
            {
                result = array[0];
            }
            else if (type == typeof (float))
            {
                result = FromFloatArray(array.Cast<float>().ToArray());
            }
            else if (type == typeof (double))
            {
                result = FromDoubleArray(array.Cast<double>().ToArray());
            }
            else
            {
                result = array;
            }
            return true;
        }

        private object FromFloatArray(float[] array)
        {
            switch (array.Length)
            {
                case 2:
                    return new Vect2f(array);
                case 3:
                    return new Vect3f(array);
                case 4:
                    return new Vect4f(array);
                default:
                    return new Vectf(array);
            }
        }
        private object FromDoubleArray(double[] array)
        {
            switch (array.Length)
            {
                case 2:
                    return new Vect2(array);
                case 3:
                    return new Vect3(array);
                case 4:
                    return new Vect4(array);
                default:
                    return new Vect(array);
            }
        }
    }
}
