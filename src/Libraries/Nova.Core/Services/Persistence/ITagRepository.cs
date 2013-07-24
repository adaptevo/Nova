using Nova.Core.Domain;

namespace Nova.Core.Services.Persistence
{
    public interface ITagRepository
    {
        Tag Find(string name);
        Tag Get(int id);
    }
}
