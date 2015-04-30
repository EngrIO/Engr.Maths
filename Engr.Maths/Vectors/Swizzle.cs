using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Engr.Maths.Vectors
{
    public class Swizzle : DynamicObject
    {
        private readonly Dictionary<char, double> _members = new Dictionary<char, double>();

        public Swizzle(Vect2 v)
        {
            _members.Add('X', v.X);
            _members.Add('Y', v.Y);
        }

        public Swizzle(Vect3 v)
        {
            _members.Add('X', v.X);
            _members.Add('Y', v.Y);
            _members.Add('Z', v.Z);
        }

        public Swizzle(Vect4 v)
        {
            _members.Add('X', v.X);
            _members.Add('Y', v.Y);
            _members.Add('Z', v.Z);
            _members.Add('W', v.W);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var array = binder.Name.Select(c =>
            {
                double value;
                if (_members.TryGetValue(c, out value))
                {
                    return value;
                }
                throw new Exception(String.Format("Member Does Not Exist: {0}", c));
            }).ToArray();

            switch (binder.Name.Length)
            {
                case 1:
                    result = array[0];
                    break;
                case 2:
                    result = new Vect2(array);
                    break;
                case 3:
                    result = new Vect3(array);
                    break;
                case 4:
                    result = new Vect4(array);
                    break;
                default:
                    result = new Vect(array);
                    break;
            }
            return true;
        }
    }
}
