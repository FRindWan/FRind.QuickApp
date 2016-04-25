/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/25 星期一 18:06:28
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using QuickApp.Domain.Entites;
using QuickApp.Exceptions;
using System.Transactions;

namespace QuickApp.Data
{
    /// <summary>
    /// <see cref="QuickDataContext"/>
    /// </summary>
    public abstract class QuickDataContext : IDisposable
    {
        private IDbConnection connection;
        private bool canExecuteSql = false;
        private TransactionScope transactionScope;

        public QuickDataContext(string nameOrConnectString)
        {
            if (String.IsNullOrWhiteSpace(nameOrConnectString))
            {
                throw new ArgumentNullException("初始化之前，请传入有效的数据库连接信息！");
            }

            this.connection = this.InitializeConnection();

        }

        public void Dispose()
        {
            if (this.connection == null)
            {
                return;
            }

            this.connection.Dispose();
            this.connection = null;

            this.transactionScope.Dispose();
            this.transactionScope = null;
        }

        public void BeginTransaction()
        {
            this.transactionScope = new TransactionScope();
            this.canExecuteSql = true;
        }

        public void Commit()
        {
            this.transactionScope.Complete();
            this.transactionScope = null;
            this.canExecuteSql = false;
        }

        public T ExecuteSql<T>(string sqlstring,object param=null)
        {
            if (!this.canExecuteSql)
            {
                throw new QuickAppException("目前框架不允许自定义调用执行Sql语句！");
            }

            return this.connection.ExecuteScalar<T>(sqlstring, param);
        }

        public Task<T> ExecuteSqlAsync<T>(string sqlstring, object param = null)
        {
            if (!this.canExecuteSql)
            {
                throw new QuickAppException("目前框架不允许自定义调用执行Sql语句！");
            }

            return this.connection.ExecuteScalarAsync<T>(sqlstring, param);
        }

        public IDataReader ExecuteReader(String sqlstring, object param = null)
        {
            return this.connection.ExecuteReader(sqlstring, param);
        }

        public Task<IDataReader> ExecuteReaderAsync(String sqlstring, object param = null)
        {
            return this.connection.ExecuteReaderAsync(sqlstring, param);
        }

        public IEnumerable<T> Query<T>(string sqlstring, object param = null)
        {
            return this.connection.Query<T>(sqlstring, param);
        }

        protected abstract IDbConnection InitializeConnection();

    }
}
