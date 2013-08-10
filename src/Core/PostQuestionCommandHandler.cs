using Nova.Core.Application;
using Nova.Core.Domain;
using Nova.Core.Services.Context;
using Nova.Core.Services.Persistence;
using Nova.Framework.Utilities;

namespace Nova.Core
{
    public class PostQuestionCommandHandler : ICommandHandler<PostQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITagService _tagService;

        public PostQuestionCommandHandler(IQuestionRepository questionRepository, ITagService tagService)
        {
            _questionRepository = CheckArgument.NotNull(questionRepository, "questionRepository");
            _tagService = CheckArgument.NotNull(tagService, "tagService");
        }

        public void Handle(PostQuestionCommand command)
        {
            Tag tag = (string.IsNullOrWhiteSpace(command.TagName)) ? _tagService.GetDefaultTag() : new Tag(command.TagName);

            var question = new Question(command.Question, command.Keywords);
            question.AddTag(tag);
            _questionRepository.Add(question);
            _questionRepository.PersistChanges();
            command.QuestionId = question.Id;
        }
    }
}
