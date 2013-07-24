using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;

namespace Nova.Core.Services.Context
{
    public class MockUserContext : IUserContext
    {
        private static readonly User _currentUser = new User("joejose", "Joseph Jose");

        public User CurrentUser
        {
            get { return _currentUser; }
        }
    }
}
