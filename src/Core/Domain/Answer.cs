using Nova.Core.Utilities;
using System;

namespace Nova.Core.Domain
{
    public class Answer
    {
        private int _id;
        private readonly Question _question;
        private readonly string _value;
        private readonly User _user;
        private DateTime _dateTimeAnswered;

        public Answer(Question question, string value, User user)
        {
            _question = CheckArgument.NotNull(question, "question");
            _value = CheckArgument.NotNull(value, "value");
            _user = CheckArgument.NotNull(user, "user");
        }

        public int Id
        {
            get { return _id; }
            private set { _id = CheckArgument.NotDefault(value, "value (Id)"); }
        }

        public Question Question { get { return _question; } }
        public string Value { get { return _value; } }
        public User User { get { return _user; } }

        public DateTime DateTimeAnswered 
        {
            get { return _dateTimeAnswered; }
            private set { _dateTimeAnswered = CheckArgument.NotDefault(value, "value (DateTimeAnswered)"); }
        }
    }
}
