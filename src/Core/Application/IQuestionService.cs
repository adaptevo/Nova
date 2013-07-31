using System.Collections.Generic;
using Nova.Core.Domain;

namespace Nova.Core.Application
{
    public interface IQuestionService
    {
        int PostQuestion(string inquiry, string keywords, string tagName);
        int AnswerQuestion(int questionId, string reply);
        void CommentOnQuesiton(int questionId, string comment);
        void CommentOnAnswer(int answerId, string comment);
        IEnumerable<Answer> GetSuggestedAnswers(int questionId, string phrase);
    }
}
