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

        protected User() { }

        public User(string id, string name)
        {
            Id = id;
            Name = name;
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
    }
}
