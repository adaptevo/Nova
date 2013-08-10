using CuttingEdge.Conditions;

namespace Nova.Core.Domain
{
    public class Answer
    {
        private Question _question; 
        private string _value;

        protected Answer() { }

        public Answer(Question question, string value)
        {
            Question = question;
            Value = value;
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
