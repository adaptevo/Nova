using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Services.Persistence;
using Nova.Core.Domain;
using CuttingEdge.Conditions;
using NHibernate;
using NHibernate.Linq;
using CuttingEdge.Conditions;

namespace Nova.Services.Persistence.NHibernate
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            Condition.Requires(session, "session").IsNotNull();
            _session = session;
        }

        public User UpdateUser(User User)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int UserId)
        {
            return _session.Query<User>().ToArray().Where(x => x.Id == UserId.ToString()).SingleOrDefault();
        }

        public void DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string username, string password, string name, string email)
        {
            User user = new User(new Guid().ToString(), name, username, password, email);
            _session.Save(user);
            PersistChanges();
            return GetUser(username, password);
        }

        public void PersistChanges()
        {
            _session.Flush();
        }


        public User GetUser(string username, string password)
        {
            return _session.Query<User>().ToArray().Where(x => x.Username == username && x.Password == password).SingleOrDefault();
        }
    }
}
