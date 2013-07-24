using System;
using System.Collections.Generic;
using Nova.Core.Domain;

namespace Nova.Core.Application
{
    public class TagService : ITagService
    {
        public Tag GetDefaultTag()
        {
            return new Tag("General");
        }

        public IEnumerable<Tag> GetSuggestedTags(string phrase)
        {
            throw new NotImplementedException();
        }
    }
}
