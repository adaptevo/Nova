using FluentNHibernate.Mapping;
using Nova.Core.Domain;

namespace Nova.Services.Persistence.NHibernate.Mappings
{
    internal class AnswerMap : ClassMap<Answer>
    {
        public AnswerMap()
        {
            Id(answer => answer.Id);
            Map(answer => answer.Value);
            References(answer => answer.Question);
        }
    }
}
