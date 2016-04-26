/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 11:37:33
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure.MSSqlerver
{
    /// <summary>
    /// <see cref="MSSqlConnectionPoolFactory"/>
    /// </summary>
    public class MSSqlConnectionPoolFactory:ConnectionPoolFactory<SqlConnection>
    {
        public MSSqlConnectionPoolFactory(int poolSize, string connectionString)
            : base(poolSize, connectionString)
        { }

        protected override ConnectPool<SqlConnection> GetPool()
        {
            return new MSSqlConnectionPool(this.PoolSize, this.ConnectionString);
        }
    }
}
