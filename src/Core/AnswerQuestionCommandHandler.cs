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
            CheckArgument.IsValid(command.QuestionId.IsTransient, command.QuestionId.Value.ToString(), "AnswerQuestionCommand.QuestionId");
            CheckArgument.NotEmpty(command.Answer, "AnswerQuestionCommand.Answer");

            Question question = _questionRepository.Get(command.QuestionId.Value);
            Answer answer = new Answer(question, command.Answer);
            question.Answers.Add(answer);
            _questionRepository.PersistChanges();
        }
    }
}
