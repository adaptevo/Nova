﻿using System.Collections.Generic;
using CuttingEdge.Conditions;
using System.Linq;

namespace Nova.Core.Domain
{
    public class Question
    {
        private int _id;
        private string _value;
        private string _keywords;
        protected ICollection<Tag> _tags;
        protected ICollection<Answer> _answers;

        protected Question()
        {
            _tags = new List<Tag>();
            _answers = new List<Answer>();
        }

        public Question(string value, string keywords, Tag tag)
            : this()
        {
            Value = value;
            Keywords = keywords;
            AddTag(tag);
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

        public IEnumerable<Tag> Tags { get { return _tags; } }
        public IEnumerable<Answer> Answers { get { return _answers; } }

        public void Answer(string value)
        {
            Condition.Requires(value).IsNotEmpty();
            _answers.Add(new Answer(this, value));
        }

        public void AddTag(Tag tag)
        {
            Condition.Requires(tag, "tag").IsNotNull();
            _tags.Add(tag);
        }
    }
}
