using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Domain;

namespace Nova.Core
{
    public class CreateUserQuery : IQuery<User>
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
