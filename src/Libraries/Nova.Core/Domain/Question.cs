﻿using Nova.Core.Utilities;
using System.Collections.Generic;

namespace Nova.Core.Domain
{
    public class Question
    {
        private int _id;
        private readonly string _value;
        private readonly string _keyword;
        private readonly List<QuestionText> _suggestedQuestionText;
        private readonly List<Tag> _tags;
        private readonly List<Answer> _answers;

        public Question(string value, string keywords, Tag tag, User user)
        {
            var questionText = new QuestionText(this, value, keywords, user);
            _value = questionText.Value;
            _keyword = questionText.Keyword;
            _suggestedQuestionText = new List<QuestionText>() { questionText };
            _tags = new List<Tag>() { CheckArgument.NotNull(tag, "tag") };
            _answers = new List<Answer>();
        }

        public int Id
        {
            get { return _id; }
            private set { _id = CheckArgument.NotDefault(value, "value (Id)"); }
        }

        public string Value { get { return _value; } }
        public string Keywords { get { return _keyword; } }
        public ICollection<QuestionText> SuggestedQuestionText { get { return _suggestedQuestionText; } }
        public ICollection<Tag> Tags { get { return _tags; } }
        public ICollection<Answer> Answers { get { return _answers; } }
    }
}
