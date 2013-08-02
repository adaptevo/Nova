using Nova.Framework.Utilities;
using System;

namespace Nova.Core.Domain
{
    public class Answer
    {
        private int _id;
        private readonly Question _question;
        private readonly string _value;
        private DateTime _dateTimeAnswered;

        public Answer(Question question, string value)
        {
            _question = CheckArgument.NotNull(question, "question");
            _value = CheckArgument.NotNull(value, "value");
        }

        public int Id
        {
            get { return _id; }
            private set { _id = CheckArgument.NotDefault(value, "value (Id)"); }
        }

        public Question Question { get { return _question; } }
        public string Value { get { return _value; } }

        public DateTime DateTimeAnswered 
        {
            get { return _dateTimeAnswered; }
            private set { _dateTimeAnswered = CheckArgument.NotDefault(value, "value (DateTimeAnswered)"); }
        }
    }
}
