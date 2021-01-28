using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using PogoRaidsBackend.Mappings;

namespace PogoRaidsBackend.Helpers
{
    public class DatabaseNHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public ISession OpenSession()
        {
            try
            {
                if(_sessionFactory == null)
                {
                    _sessionFactory = OpenSessionFactory();
                }
                ISession _session = _sessionFactory.OpenSession();
                return _session;
            }
            catch(Exception x)
            {
                throw x.InnerException ?? x;
            }
        }

        private ISessionFactory OpenSessionFactory()
        {
            var _fluentConfig = Fluently.Configure()
                .Diagnostics(diag => diag.Enable().OutputToConsole())
                .Database(SQLiteConfiguration.Standard.UsingFile("database.db"))
                .Mappings(x => x.FluentMappings.Add<UserDataModelMap>())
                .Mappings(x => x.FluentMappings.Add<TeamDataModelMap>())
                .Mappings(x => x.FluentMappings.Add<RaidDataModelMap>())
                .Mappings(x => x.FluentMappings.Add<PokemonDataModelMap>())
                .Mappings(x => x.FluentMappings.Add<DifficultyDataModelMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildConfiguration();

            _sessionFactory = _fluentConfig.BuildSessionFactory();
            return _sessionFactory;

        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("database.db"))
                //File.Delete("database.db");
                return;

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaUpdate(config).Execute(true, true);
            //new SchemaExport(config).Create(false, true);
        }
    }
}
