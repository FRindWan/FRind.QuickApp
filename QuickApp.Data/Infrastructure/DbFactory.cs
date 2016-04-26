using QuickApp.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Data.Extensions;

namespace QuickApp.Data.Infrastructure
{
    public abstract class DbFactory:IDbFactory
    {
        protected readonly String sqlConnectString;

        protected readonly Logger.Logger logger;

        public DbFactory(String nameOrConnectString)
        {
            if (String.IsNullOrEmpty(nameOrConnectString))
            {
                nameOrConnectString = "name=Default";
            }

            if (nameOrConnectString.Contains("name="))
            {
                nameOrConnectString = ConfigurationManager.ConnectionStrings[nameOrConnectString.Split('=')[1]].ToString();
            }
            this.sqlConnectString = nameOrConnectString;

            this.logger = Logger.Logger.GetLogger(this.GetType());
        }

        public abstract DataBaseType DbType { get; }

        public abstract bool ExecuteSql(String strsql, params object[] parameters);

        public abstract DataTable ExecuteDataTable(String strsql, params object[] parameters);

        public abstract object ExecuteResult(String strsql, params object[] parameters);

        public abstract TEntity Find<TEntity>(string strsql, params object[] parameters) where TEntity : class;

        public abstract IEnumerable<TEntity> FindAll<TEntity>(string strsql, params object[] parameters) where TEntity : class;

        public void Dispose()
        {
            this.dispose();
        }

        protected abstract void dispose();

        public static IDbFactory Create(String nameOfConnectString,DataBaseType DataBaseType)
        {
            switch (DataBaseType)
            {
                case DataBaseType.MSSQLSERVER: return new MSSqlerver.MSSqlDbFactory(nameOfConnectString);
            }

            return null;
        }





    }
}
