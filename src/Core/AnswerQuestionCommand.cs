using Nova.Core.Domain;

namespace Nova.Core
{
    public class AnswerQuestionCommand
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
