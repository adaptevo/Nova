using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;
using Nova.Core.Utilities;
using Nova.Core.Services.Configuration;
using Nova.Core.Services.Persistence;
using Nova.Core.Services.Context;

namespace Nova.Core.Application
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ITagService _tagService;
        private readonly IUserContext _userContext;

        public QuestionService(IQuestionRepository questionRepository, ITagRepository tagRepository, ITagService tagService, IUserContext userContext)
        {
            _questionRepository = CheckArgument.NotNull(questionRepository, "questionRepository");
            _tagRepository = CheckArgument.NotNull(tagRepository, "tagRepository");
            _tagService = CheckArgument.NotNull(tagService, "tagService");
            _userContext = CheckArgument.NotNull(userContext, "userContext");
        }

        public int PostQuestion(string inquiry, string keywords, int? tagId)
        {
            CheckArgument.NotEmpty(inquiry, "inquiry");
            CheckArgument.NotEmpty(keywords, "keywords");

            Tag tag = (tagId.HasValue) ? _tagRepository.Get(tagId.Value) : _tagService.GetDefaultTag();

            var question = new Question(inquiry, keywords, tag);
            _questionRepository.Add(question);
            _questionRepository.PersistChanges();
            return question.Id;
        }

        public int AnswerQuestion(int questionId, string reply)
        {
            Question question = _questionRepository.Get(CheckArgument.NotDefault(questionId, "questionId"));
            Answer answer = question.Answers.SingleOrDefault(a => a.AnswerText == reply);

            if (answer == default(Answer))
            {
                answer = new Answer(question, reply, _userContext.CurrentUser);
            }
            else
            {
                answer.UserAnswers.Add(new UserAnswer(answer, _userContext.CurrentUser));
            }

            _questionRepository.PersistChanges();
            return answer.Id;
        }

        public void CommentOnQuesiton(int questionId, string comment)
        {
            throw new NotImplementedException();
        }

        public void CommentOnAnswer(int answerId, string comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetSuggestedAnswers(int questionId, string phrase)
        {
            throw new NotImplementedException();
        }
    }
}
