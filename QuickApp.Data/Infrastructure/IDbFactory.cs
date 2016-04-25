using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        DbFactoryType DbType { get; }

        bool ExecuteSql(String strsql, params object[] parameters);

        DataTable ExecuteDataTable(String strsql, params object[] parameters);

        object ExecuteResult(String strsql, params object[] parameters);

        TEntity Find<TEntity>(String strsql, params object[] parameters) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity>(String strsql, params object[] parameters) where TEntity : class;
    }
}
