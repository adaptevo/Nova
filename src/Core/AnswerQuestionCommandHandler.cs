using Nova.Core.Application;
using Nova.Core.Domain;
using Nova.Core.Services.Context;
using Nova.Core.Services.Persistence;
using Nova.Framework.Utilities;

namespace Nova.Core
{
    public class AnswerQuestionCommandHandler : ICommandHandler<AnswerQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;

        public AnswerQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = CheckArgument.NotNull(questionRepository, "questionRepository");
        }

        public void Handle(AnswerQuestionCommand command)
        {
            Question question = _questionRepository.Get(command.QuestionId);
            question.Answer(command.Answer);
            _questionRepository.PersistChanges();
        }
    }
}
