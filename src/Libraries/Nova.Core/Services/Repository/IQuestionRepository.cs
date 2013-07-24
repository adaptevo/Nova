using Nova.Core.Domain;

namespace Nova.Core.Services.Repository
{
    public interface IQuestionRepository
    {
        Question Get(int id);
        void Add(Question question);
        void PersistChanges();
    }
}
