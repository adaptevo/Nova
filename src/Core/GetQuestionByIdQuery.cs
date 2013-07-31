using Nova.Core.Domain;

namespace Nova.Core
{
    public class GetQuestionByIdQuery : IQuery<Question>
    {
        public int QuestionId { get; set; }
    }
}
