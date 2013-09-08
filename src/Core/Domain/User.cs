using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Framework.Utilities;
using CuttingEdge.Conditions;

namespace Nova.Core.Domain
{
    public class User
    {
        private string _id;
        private string _name;
        private string _username;
        private string _password;
        private string _email;

        protected User() { }

        public User(string id)
        {
            Id = id;
        }

        public User(string id, string name) 
            : this(id)
        {
            Name = name;
        }

        public User(string id, string name, string username, string password, string email)
            : this(id, name)
        {
            Username = username;
            Password = password;
            Email = email;

        }

        public virtual string Id
        {
            get { return _id; }
            protected set
            {
                Condition.Requires(value, "value (Id)").IsNotNullOrWhiteSpace();
                _id = value;
            }
        }

        public virtual string Name
        {
            get { return _name; }
            protected set
            {
                Condition.Requires(value, "value (Name)").IsNotNullOrWhiteSpace();
                _name = value;
            }
        }

        public virtual string Username
        {
            get { return _username; }
            protected set
            {
                Condition.Requires(value, "value (Username)").IsNotNullOrWhiteSpace();
                _username = value;
            }
        }

        public virtual string Password
        {
            get { return _password; }
            set
            {
                Condition.Requires(value, "value (Password)").IsNotNullOrWhiteSpace();
                _password = value;

            }
        }

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }


    }
}
