using System;
using System.Collections.Generic;
using Nova.Core.Domain;
using Nova.Core.Services.Context;
using Nova.Core.Utilities;

namespace Nova.Core.Application
{
    public class TagService : ITagService
    {
        private readonly IUserContext _userContext;

        public TagService(IUserContext userContext)
        {
            _userContext = CheckArgument.NotNull(userContext, "userContext");
        }

        public Tag GetDefaultTag()
        {
            return new Tag("General", _userContext.CurrentUser);
        }

        public IEnumerable<Tag> GetSuggestedTags(string phrase)
        {
            throw new NotImplementedException();
        }
    }
}
