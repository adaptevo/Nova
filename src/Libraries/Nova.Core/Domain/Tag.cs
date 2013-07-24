using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nova.Core.Utilities;

namespace Nova.Core.Domain
{
    public class Tag
    {
        public Tag(string name)
        {
            Name = CheckArgument.NotEmpty(name, "name");
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
