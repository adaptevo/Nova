using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;

namespace Nova.Core.Services.Persistence
{
    public interface IUserRepository
    {
        User GetUser(int UserId);
        User GetUser(string username, string password);
        User UpdateUser(User User);
        void DeleteUser(int UserId);
        User CreateUser(string username, string password, string name, string email);
    }
}
