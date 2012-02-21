using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace FluentNHSample {
    public static class SessionFactoryBuilder {
        public static ISessionFactory BuildSessionFactory<TMappingClass, TMappingConvention>(String connectionString) {
            return Fluently.Configure()
                   .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.Is(connectionString))).
                    Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<TMappingClass>()
                            .Conventions.AddFromAssemblyOf<TMappingConvention>()
                            )
                    .BuildSessionFactory();
        }

        public static ISessionFactory BuildSessionFactoryFromAppConfig<TMappingClass, TMappingConvention>(String connectionStringKeyInAppConfig) {
            return Fluently.Configure()
                   .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKeyInAppConfig))).
                    Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<TMappingClass>()
                            .Conventions.AddFromAssemblyOf<TMappingConvention>()
                            )
                    .BuildSessionFactory();
        }
    }
}
