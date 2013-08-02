using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Framework.Utilities;

namespace Nova.Core.Domain
{
    public class Tag
    {
        private int _id;
        private readonly string _name;
        private Tag _parent;

        public Tag(string name)
        {
            _name = CheckArgument.NotEmpty(name, "name");
        }

        public int Id 
        {
            get { return _id; }
            private set { _id = CheckArgument.NotDefault(value, "value (Id)"); }
        }

        public string Name { get { return _name; } }

        public Tag Parent 
        {
            get { return _parent; }
            set { _parent = CheckArgument.NotNull(value, "value (Parent)"); }
        }
    }
}
