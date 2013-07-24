using Nova.Core.Domain;
using System.Collections.Generic;

namespace Nova.Core.Services.Persistence
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        Question Get(int id);
        void Add(Question question);
        void PersistChanges();
    }
}
