using System.Collections.Generic;
using Nova.Core.Domain;

namespace Nova.Core.Application
{
    public interface ITagService
    {
        Tag GetDefaultTag();
        IEnumerable<Tag> GetSuggestedTags(string phrase);
    }
}
