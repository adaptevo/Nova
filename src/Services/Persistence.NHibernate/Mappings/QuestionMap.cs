using FluentNHibernate.Mapping;
using Nova.Core.Domain;

namespace Nova.Services.Persistence.NHibernate.Mappings
{
    internal class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(question => question.Id);
            Map(question => question.Value);
            Map(question => question.Keywords);
            HasMany(question => question.Tags);
            HasMany(question => question.Answers);
        }
    }
}
