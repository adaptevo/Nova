using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Utilities;

namespace Nova.Core.Domain
{
    public class User
    {
        private readonly string _userId;

        public User(string userId, string name)
        {
            _userId = CheckArgument.NotEmpty(userId, "userId");
            Name = CheckArgument.NotEmpty(name, "name");
        }

        public string UserId { get { return _userId; } }
        public string Name { get; set; }
    }
}
