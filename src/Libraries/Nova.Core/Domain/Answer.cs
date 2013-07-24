using System.Collections.Generic;
using Nova.Core.Utilities;

namespace Nova.Core.Domain
{
    public class Answer
    {
        private readonly Question _question;

        public Answer(Question question, string answer, User user)
        {
            AnswerText = CheckArgument.NotEmpty(answer, "answer");
            _question = CheckArgument.NotNull(question, "question");
            _question.Answers.Add(this);
            UserAnswers = new List<UserAnswer>() { new UserAnswer(this, user) };
        }

        public int Id { get; private set; }
        public string AnswerText { get; private set; }
        public Question Question { get { return _question; } }
        public ICollection<UserAnswer> UserAnswers { get; private set; }
    }
}
