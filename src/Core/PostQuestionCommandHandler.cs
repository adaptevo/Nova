using Nova.Core.Application;
using Nova.Core.Domain;
using Nova.Core.Services.Context;
using Nova.Core.Services.Persistence;
using Nova.Core.Utilities;

namespace Nova.Core
{
    public class PostQuestionCommandHandler : ICommandHandler<PostQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITagService _tagService;
        private readonly IUserContext _userContext;

        public PostQuestionCommandHandler(IQuestionRepository questionRepository, ITagService tagService, IUserContext userContext)
        {
            _questionRepository = CheckArgument.NotNull(questionRepository, "questionRepository");
            _tagService = CheckArgument.NotNull(tagService, "tagService");
            _userContext = CheckArgument.NotNull(userContext, "userContext");
        }

        public void Handle(PostQuestionCommand command)
        {
            CheckArgument.NotEmpty(command.Question, "PostQuestionCommand.Question");
            CheckArgument.NotEmpty(command.Keywords, "PostQuestionCommand.Keywords");

            Tag tag = (string.IsNullOrWhiteSpace(command.TagName)) ? _tagService.GetDefaultTag() : new Tag(command.TagName, _userContext.CurrentUser);

            var question = new Question(command.Question, command.Keywords, tag, _userContext.CurrentUser);
            _questionRepository.Add(question);
            _questionRepository.PersistChanges();
            command.QuestionId = question.Id;
        }
    }
}
