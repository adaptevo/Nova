using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Framework.Utilities;

namespace Nova.Core.Domain
{
    public class IntIdentifier : IComparable<IntIdentifier>
    {
        private readonly int _id;

        private IntIdentifier()
        {
            _id = 0;
        }

        public IntIdentifier(int id)
        {
            _id = CheckArgument.GreaterThan<int>(id, 0, "id");
        }

        public int Value { get { return _id; } }

        public bool IsTransient { get { return _id == 0; } }

        public static IntIdentifier Transient { get { return new IntIdentifier(); } }

        public static bool TryCreate(int value, out IntIdentifier id)
        {
            id = null;

            if (value > 0)
            {
                id = new IntIdentifier(value);
                return true;
            }

            return false;
        }

        public static implicit operator int(IntIdentifier id)
        {
            return id.Value;
        }

        public static explicit operator IntIdentifier(int id)
        {
            return new IntIdentifier(id);
        }

        public int CompareTo(IntIdentifier other)
        {
            return _id.CompareTo(other.Value);
        }
    }
}
