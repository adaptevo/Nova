using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Utilities;

namespace Nova.Core.Domain
{
    public class QuestionText
    {
        private int _id;
        private readonly Question _question;
        private readonly string _value;
        private readonly string _keyword;

        public QuestionText(Question question, string value, string keywords)
        {
            _question = CheckArgument.NotNull(question, "question");
            _value = CheckArgument.NotEmpty(value, "value");
            _keyword = CheckArgument.NotEmpty(keywords, "keywords");
        }

        public int Id
        {
            get { return _id; }
            private set { _id = CheckArgument.NotDefault(value, "value (Id)"); }
        }
        
        public Question Question { get { return _question; } }
        public string Value { get { return _value; } }
        public string Keyword { get { return _keyword; } }
    }
}
