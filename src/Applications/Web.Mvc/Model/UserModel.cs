using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nova.Applications.Web.Mvc.Model
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}