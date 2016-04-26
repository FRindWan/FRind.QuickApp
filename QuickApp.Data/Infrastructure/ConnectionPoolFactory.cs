/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 11:30:30
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    /// <summary>
    /// <see cref="ConnectionPoolFactory"/>
    /// </summary>
    public abstract class ConnectionPoolFactory<TConnection>where TConnection:IDbConnection
    {
        private static ConnectPool<TConnection> connectionPool;
        private object sync=new object();
        private readonly int poolSize;
        private readonly string connectionString;

        public ConnectionPoolFactory(int poolSize,string connectionString)
        {
            this.poolSize = poolSize;
            this.connectionString = connectionString;
        }

        protected int PoolSize { get { return this.poolSize; } }

        protected string ConnectionString { get { return this.connectionString; } }

        public ConnectPool<TConnection> GetConnectionPool()
        {
            lock (this.sync)
            {
                if (connectionPool == null)
                {
                    lock (sync)
                    {
                        connectionPool = this.GetPool();
                    }
                }

                return connectionPool;
            }
        }

        protected abstract ConnectPool<TConnection> GetPool();
    }
}
