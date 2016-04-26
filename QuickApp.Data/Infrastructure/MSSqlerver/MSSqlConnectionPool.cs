/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 11:21:38
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
    /// <see cref="MSSqlConnectionPool"/>
    /// </summary>
    public class MSSqlConnectionPool:ConnectPool<SqlConnection>
    {
        public MSSqlConnectionPool(int poolSize, string connectionString)
            : base(poolSize, connectionString)
        { 
            
        }

        protected override SqlConnection InitializeConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(this.ConnectString);
            sqlConnection.Open();

            return sqlConnection;
        }

        protected override SqlConnection GetActivityConnection()
        {
            SqlConnection sqlConnection = this.Connections.FirstOrDefault(p => p.State == System.Data.ConnectionState.Open);
            if (sqlConnection == null)
            {
                this.InitializePool();
                return this.InitializeConnection();
            }
            sqlConnection.Close();
            sqlConnection.Open();

            return sqlConnection;
        }

        protected override void DoDispose(bool isDisposing)
        {
            if (!isDisposing)
            {
                return;
            }

            for (int i = 0; i < this.Connections.Length; i++)
            {
                this.Connections[i].Dispose();
                this.Connections[i] = null;
            }
        }
    }
}
