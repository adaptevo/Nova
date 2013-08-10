using CuttingEdge.Conditions;

namespace Nova.Core.Domain
{
    public class Answer
    {
        private int _id;
        private string _value;
        private Question _question; 

        protected Answer() { }

        public Answer(Question question, string value)
        {
            Question = question;
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

        public virtual Question Question
        {
            get { return _question; }
            protected set
            {
                Condition.Requires(value, "value (Question)").IsNotNull();
                _question = value;
            }
        }
    }
}
