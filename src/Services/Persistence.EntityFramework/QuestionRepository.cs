using System;
using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using Nova.Core.Domain;
using Nova.Core.Services.Persistence;

namespace Nova.Services.Persistence.EntityFramework
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly NovaContext _dbContext;

        public QuestionRepository(NovaContext dbContext)
        {
            Condition.Requires(dbContext, "dbContext").IsNotNull();
            _dbContext = dbContext;
        }

        public IEnumerable<Question> GetAll()
        {
            return _dbContext.Questions.ToList();
        }

        public Question Get(int id)
        {
            return _dbContext.Questions.Find(id);
        }

        public void Add(Question question)
        {
            _dbContext.Questions.Add(question);
        }

        public void PersistChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
