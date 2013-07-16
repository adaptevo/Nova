using Nova.Core.Utilities;

namespace Nova.Core.Model
{
    public class Question
    {
        public Question(string questionText)
        {
            QuestionText = CheckArgument.NotNull(questionText, "questionText");
        }

        public string QuestionId { get; private set; }
        public string QuestionText { get; set; }
    }
}
