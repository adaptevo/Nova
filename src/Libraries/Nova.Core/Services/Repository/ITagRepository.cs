using Nova.Core.Domain;

namespace Nova.Core.Services.Repository
{
    public interface ITagRepository
    {
        Tag Find(string name);
        Tag Get(int id);
    }
}
