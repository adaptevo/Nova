using CuttingEdge.Conditions;
using Nova.Framework.Utilities;

namespace Nova.Core.Domain
{
    public class Tag
    {
        private int _id;
        private string _value;

        protected Tag() { }

        public Tag(string value)
        {
            Value = value;
        }

        public virtual int Id
        {
            get { return _id; }
            protected set
            {
                Condition.Requires(value, "value (Id)").IsGreaterThan(0);
                _id = value;
            }
        }

        public virtual string Value
        {
            get { return _value; }
            protected set
            {
                Condition.Requires(value).IsNotNullOrWhiteSpace();
                _value = value;
            }
        }
    }
}
