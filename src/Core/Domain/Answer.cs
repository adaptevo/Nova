using Nova.Framework.Utilities;
using System;
using CuttingEdge.Conditions;

namespace Nova.Core.Domain
{
    public class Answer
    {
        private readonly string _value;

        public Answer(string value)
        {
            Condition.Requires(value).IsNotEmpty();
            _value = value;
        }

        public string Value { get { return _value; } }
    }
}
