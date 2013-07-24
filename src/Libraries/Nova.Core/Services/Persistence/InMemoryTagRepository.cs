using System;
using Nova.Core.Domain;

namespace Nova.Core.Services.Persistence
{
    public class InMemoryTagRepository : ITagRepository
    {
        public Tag Find(string name)
        {
            throw new NotImplementedException();
        }

        public Tag Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
