using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Services.Persistence;
using Nova.Core.Domain;
using NHibernate;
using NHibernate.Linq;
using CuttingEdge.Conditions;

namespace Nova.Services.Persistence.NHibernate
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ISession _session;

        public QuestionRepository(ISession session)
        {
            Condition.Requires(session, "session").IsNotNull();
            _session = session;
        }

        public IEnumerable<Question> GetAll()
        {
            return _session.Query<Question>().ToArray();
        }

        public Question Get(int id)
        {
            return _session.Get<Question>(id);
        }

        public void Add(Question question)
        {
            _session.Save(question);
        }

        public void PersistChanges()
        {
            _session.Flush();
        }
    }
}
