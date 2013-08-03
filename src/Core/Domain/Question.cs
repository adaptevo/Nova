using System.Collections.Generic;
using CuttingEdge.Conditions;

namespace Nova.Core.Domain
{
    public class Question
    {
        private IntIdentifier _id;
        private readonly string _value;
        private readonly string _keyword;
        private readonly List<QuestionText> _suggestedQuestionText;
        private readonly List<Tag> _tags;
        private readonly List<Answer> _answers;

        public Question(string value, string keywords, Tag tag)
        {
            Condition.Requires(value).IsNotEmpty();
            Condition.Requires(keywords, "keywords").IsNotEmpty();
            Condition.Requires(tag, "tag").IsNotNull();

            var questionText = new QuestionText(value, keywords);
            _suggestedQuestionText = new List<QuestionText>() { questionText };

            _id = IntIdentifier.Transient;
            _value = questionText.Value;
            _keyword = questionText.Keyword;
            _tags = new List<Tag>() { tag };
            _answers = new List<Answer>();
        }

        public IntIdentifier Id
        {
            get { return _id; }
            private set 
            {
                Condition.Requires(value).IsNotNull();
                _id = value; 
            }
        }

        public string Value { get { return _value; } }
        public string Keywords { get { return _keyword; } }
        public IEnumerable<QuestionText> SuggestedQuestionText { get { return _suggestedQuestionText.ToArray(); } }
        public IEnumerable<Tag> Tags { get { return _tags.ToArray(); } }
        public IEnumerable<Answer> Answers { get { return _answers.ToArray(); } }

        public void Answer(string value)
        {
            _answers.Add(new Answer(value));
        }
    }
}
