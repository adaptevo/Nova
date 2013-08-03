using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Framework.Utilities;
using CuttingEdge.Conditions;

namespace Nova.Core.Domain
{
    public class QuestionText
    {
        private readonly string _value;
        private readonly string _keyword;

        public QuestionText(string value, string keywords)
        {
            Condition.Requires(value, "value").IsNotEmpty();
            Condition.Requires(keywords, "keywords").IsNotEmpty();

            _value = value;
            _keyword = keywords;
        }

        public string Value { get { return _value; } }
        public string Keyword { get { return _keyword; } }
    }
}
