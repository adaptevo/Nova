using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;
using Nova.Framework.Utilities;
using Nova.Core.Services.Configuration;
using Nova.Core.Services.Persistence;
using Nova.Core.Services.Context;

namespace Nova.Core.Application
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITagService _tagService;
        private readonly IUserContext _userContext;

        public QuestionService(IQuestionRepository questionRepository, ITagService tagService, IUserContext userContext)
        {
            _questionRepository = CheckArgument.NotNull(questionRepository, "questionRepository");
            _tagService = CheckArgument.NotNull(tagService, "tagService");
            _userContext = CheckArgument.NotNull(userContext, "userContext");
        }

        public int PostQuestion(string value, string keywords, string tagName)
        {
            CheckArgument.NotEmpty(value, "value");
            CheckArgument.NotEmpty(keywords, "keywords");

            Tag tag = (string.IsNullOrWhiteSpace(tagName)) ? _tagService.GetDefaultTag() : new Tag(tagName);

            var question = new Question(value, keywords, tag);
            _questionRepository.Add(question);
            _questionRepository.PersistChanges();
            return question.Id;
        }

        public int AnswerQuestion(int questionId, string reply)
        {
            Question question = _questionRepository.Get(CheckArgument.NotDefault(questionId, "questionId"));
            Answer answer = new Answer(question, reply);
            question.Answers.Add(answer);
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
