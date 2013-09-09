using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Services.Persistence;
using CuttingEdge.Conditions;
using Nova.Core.Domain;
namespace Nova.Services.Persistence.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private readonly NovaContext _dbContext;

        public UserRepository(NovaContext dbContext)
        {
            Condition.Requires(dbContext, "dbContext").IsNotNull();
            _dbContext = dbContext;
        }

        public User UpdateUser(User User)
        {
            var user = _dbContext.Users.Where(x => x.Id == User.Id).SingleOrDefault();
            if (user != null)
            {
                user = User;
            }

            return User;
        }

        public User GetUser(int UserId)
        {
            return _dbContext.Users.Where(x => x.Id == UserId.ToString()).SingleOrDefault();
        }

        public void DeleteUser(int UserId)
        {
            var user = GetUser(UserId);
            
            if (user == null)
            {
                throw new ArgumentException("UserId");
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public User CreateUser(string username, string password, string name, string email)
        {
            _dbContext.Users.Add(new User(Guid.NewGuid().ToString(), name,username,password,email));
            _dbContext.SaveChanges();
            return _dbContext.Users.Last();

        }


        public User GetUser(string username, string password)
        {
            return _dbContext.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).SingleOrDefault();
        }


        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users;
        }
    }
}
