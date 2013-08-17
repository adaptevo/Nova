using System.Collections.Generic;
using CuttingEdge.Conditions;
using System.Linq;

namespace Nova.Core.Domain
{
    public class Question
    {
        private int _id;
        private string _value;
        private string _keywords;
        private ICollection<Tag> _tags;
        private ICollection<Answer> _answers;

        protected Question()
        {
            _tags = new List<Tag>();
            _answers = new List<Answer>();
        }

        public Question(string value, string keywords)
            : this()
        {
            Value = value;
            Keywords = keywords;
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

        public virtual string Keywords 
        {
            get { return _keywords; }
            protected set
            {
                Condition.Requires(value, "value (Keywords)").IsNotNullOrWhiteSpace();
                _keywords = value;
            } 
        }

        public virtual IEnumerable<Tag> Tags { get { return _tags; } }
        public virtual IEnumerable<Answer> Answers { get { return _answers; } }

        public virtual void Answer(string value)
        {
            Condition.Requires(value).IsNotEmpty();
            _answers.Add(new Answer(this, value));
        }

        public virtual void AddTag(Tag tag)
        {
            Condition.Requires(tag, "tag").IsNotNull();
            _tags.Add(tag);
        }
    }
}
