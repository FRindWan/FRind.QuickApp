/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 11:13:57
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    /// <summary>
    /// <see cref="ConnectPool"/>
    /// </summary>
    public abstract class ConnectPool<TConnection>:IDisposable where TConnection:IDbConnection
    {
        private readonly TConnection[] connectionList;
        private readonly string connectionString;

        public ConnectPool(int poolSize,string connectString)
        {
            if (poolSize <= 0 || poolSize > 10)
            {
                throw new QuickAppException("连接池大小取值范围应在1-10之间，当前取值不合法！");
            }

            if (String.IsNullOrWhiteSpace(connectString))
            {
                throw new QuickAppException("数据库连接信息不合法！");
            }

            this.connectionString = connectString;
            this.connectionList = new TConnection[poolSize];

            InitializePool();
        }

        protected TConnection[] Connections{get{return this.connectionList;}}

        protected string ConnectString { get { return this.connectionString; } }

        public TConnection GetConnection()
        {
            return this.GetActivityConnection();
        }

        public void Dispose()
        {
            this.DoDispose(true);
        }

        protected void InitializePool()
        {
            for (int i = 0; i < this.connectionList.Length; i++)
            {
                this.connectionList[i] = this.InitializeConnection();
            }
        }

        protected abstract TConnection InitializeConnection();

        protected abstract TConnection GetActivityConnection();

        protected abstract void DoDispose(bool isDisposing);
    }
}
