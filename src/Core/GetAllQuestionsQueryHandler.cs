using System.Collections.Generic;
using System.Linq;
using Nova.Core.Domain;
using Nova.Core.Services.Persistence;
using Nova.Core.Utilities;

namespace Nova.Core
{
    public class GetAllQuestionsQueryHandler : IQueryHandler<GetAllQuestionsQuery, IEnumerable<Question>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetAllQuestionsQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = CheckArgument.NotNull(questionRepository, "questionRepository");
        }

        public IEnumerable<Question> Handle(GetAllQuestionsQuery query)
        {
            return _questionRepository.GetAll().ToArray();
        }
    }
}
