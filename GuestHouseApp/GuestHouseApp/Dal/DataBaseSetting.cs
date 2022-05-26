using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GuestHouseApp.Dal
{
    public class DataBaseSetting
    {
        public static ISession openSession()
        {
            var cfg = new Configuration();
            var path = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nHibernate\\hibernate.cfg.xml"));
            cfg.Configure(path);
            ISessionFactory sefact = cfg.BuildSessionFactory();
            return sefact.OpenSession();
        }
    }
}