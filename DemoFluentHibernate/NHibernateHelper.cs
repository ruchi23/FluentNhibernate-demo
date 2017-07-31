using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoFluentHibernate
{
    class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        public static string ReadWrite { get; private set; }

        private static void InitializeSessionFactory()
        {
            //string Data_Source = "(localdb)\v11.0";
            //string Initial_Catalog = "FluentNHibernate";
            //bool Integrated_Security = true;
            //int Connect_Timeout = 15;
            //bool Encrypt = false;
            //bool TrustServerCertificate = false;
            //string ApplicationIntent = ReadWrite;
            //bool MultiSubnetFailover = false;

            _sessionFactory = Fluently.Configure()
         .Database(MsSqlConfiguration.MsSql2012
         .ConnectionString(
             @"Server=(localdb)\v11.0;initial catalog=FluentHibernate;Integrated Security=True") 
.ShowSql())

         .Mappings(m => m.FluentMappings
         .AddFromAssemblyOf<Program>())
         .ExposeConfiguration(cfg => new SchemaExport(cfg)
         .Create(true, true))
         .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
//FluentHibernateConnectionString
//Data Source + Initial Catalog + Integrated Security + Connect Timeout
         //   + Encrypt + TrustServerCertificate + ApplicationIntent + 
            //MultiSubnetFailover