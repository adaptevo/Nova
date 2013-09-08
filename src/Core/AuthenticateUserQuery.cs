using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;

namespace Nova.Core
{
    public class AuthenticateUserQuery : IQuery<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
