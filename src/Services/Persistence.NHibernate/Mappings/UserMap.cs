using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Nova.Core.Domain;

namespace Nova.Services.Persistence.NHibernate.Mappings
{
    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(user => user.Id);
            Map(user => user.Name);
            Map(user => user.Password);
            Map(user => user.Username);
            Map(user => user.Email);
        }
    }
}
