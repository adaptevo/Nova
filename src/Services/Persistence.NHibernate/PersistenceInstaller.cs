using Nova.Framework.InversionOfControl;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using Nova.Services.Persistence.NHibernate.Mappings;
using NHibernate.Tool.hbm2ddl;
using Nova.Core.Services.Persistence;

namespace Nova.Services.Persistence.NHibernate
{
    public class PersistenceInstaller : IInstaller
    {
        public void Install(IRegister container)
        {
            container.Register<ISessionFactory>(() => BuildDatabaseConfiguration().BuildSessionFactory(), 
                Lifetime.Singleton);
            container.Register<ISession, ISessionFactory>((factory) => factory.OpenSession(), 
                Lifetime.PerWebRequest);
            container.Register<IQuestionRepository, QuestionRepository>(Lifetime.Transient);
            container.Register<IUserRepository, UserRepository>(Lifetime.Transient);
        }

        private Configuration BuildDatabaseConfiguration()
        {
            return Fluently.Configure()
                .Database(SetupDatabase)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<QuestionMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .ExposeConfiguration(ConfigurePersistence)
                .BuildConfiguration();
        }

        private IPersistenceConfigurer SetupDatabase()
        {
            return MsSqlConfiguration.MsSql2008
                .UseOuterJoin()
                .ConnectionString(x => x.FromConnectionStringWithKey("NovaDatabase"))
                .ShowSql();
        }

        private void ConfigurePersistence(Configuration config)
        {
            new SchemaUpdate(config).Execute(false, true);
        }
    }
}
