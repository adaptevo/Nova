using FluentNHibernate.Mapping;
using Nova.Core.Domain;

namespace Nova.Services.Persistence.NHibernate.Mappings
{
    internal class TagMap : ClassMap<Tag>
    {
        public TagMap()
        {
            Id(tag => tag.Id);
            Map(tag => tag.Value);
        }
    }
}
