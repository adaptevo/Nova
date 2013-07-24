using Nova.Core.Utilities;
using System.Collections.Generic;

namespace Nova.Core.Domain
{
    public class Question
    {
        public Question(string question, string keywords, Tag tag)
        {
            QuestionText = CheckArgument.NotEmpty(question, "question");
            Keywords = CheckArgument.NotEmpty(keywords, "keywords");
            Tags = new List<Tag>() { CheckArgument.NotNull(tag, "tag") };
            Answers = new List<Answer>();
        }

        public int Id { get; private set; }
        public string QuestionText { get; private set; }
        public string Keywords { get; private set; }
        public ICollection<Tag> Tags { get; private set; }
        public ICollection<Answer> Answers { get; private set; }
    }
}
