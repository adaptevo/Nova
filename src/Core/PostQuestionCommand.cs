
namespace Nova.Core
{
    public class PostQuestionCommand
    {
        public string Question { get; set; }
        public string Keywords { get; set; }
        public string TagName { get; set; }

        public int QuestionId { get; internal set; }
    }
}
