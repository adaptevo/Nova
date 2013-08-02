using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;
using Nova.Core.Services.Persistence;
using Nova.Framework.Utilities;

namespace Nova.Core
{
    public class GetQuestionByIdQueryHandler : IQueryHandler<GetQuestionByIdQuery, Question>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionByIdQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = CheckArgument.NotNull(questionRepository, "questionRepository");
        }

        public Question Handle(GetQuestionByIdQuery query)
        {
            return _questionRepository.Get(query.QuestionId);
        }
    }
}
