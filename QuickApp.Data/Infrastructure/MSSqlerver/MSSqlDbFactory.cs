using QuickApp.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Data.Extensions;
using System.Data;
using QuickApp.Exceptions;

namespace QuickApp.Data.Infrastructure.MSSqlerver
{
    public class MSSqlDbFactory:DbFactory
    {
        private readonly MSSqlConnectionPool connectionPool; 

        public MSSqlDbFactory(String nameOrConnectString):base(nameOrConnectString)
        {
            this.connectionPool = (MSSqlConnectionPool)new MSSqlConnectionPoolFactory(5, this.sqlConnectString).GetConnectionPool();
        }

        public override DbFactoryType DbType
        {
            get { return DbFactoryType.MSSQLSERVER; }
        }

        public override bool ExecuteSql(string strsql, params object[] parameters)
        {
            try
            {
                SqlConnection connection =this.connectionPool.GetConnection();
                
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = strsql;
                    command.Connection = connection;
                    if (parameters != null)
                    {
                        command.AddParams(parameters);
                    }
                    if (command.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
                
            }
            catch (Exception ex)
            {
                base.logger.Error("执行Sql语句失败，语句："+strsql+"，原因：" + ex.Message);
                throw new QuickAppException("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
            }
        }

        public override System.Data.DataTable ExecuteDataTable(string strsql, params object[] parameters)
        {
            try
            {
                SqlConnection connection =this.connectionPool.GetConnection();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = strsql;
                    command.Connection = connection;
                    if (parameters != null)
                    {
                        command.AddParams(parameters);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dataTable=new DataTable();
                    da.Fill(dataTable);
                    return dataTable;
                }
                
            }
            catch (Exception ex)
            {
                base.logger.Error("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
                throw new QuickAppException("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
            }
        }
        
        public override object ExecuteResult(string strsql, params object[] parameters)
        {
            try
            {
                SqlConnection connection =this.connectionPool.GetConnection();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = strsql;
                    command.Connection = connection;
                    if (parameters != null)
                    {
                        command.AddParams(parameters);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);

                    return dataTable.Rows[0][0];
                }
            }
            catch (Exception ex)
            {
                base.logger.Error("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
                throw new QuickAppException("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
            }
        }

        public override TEntity Find<TEntity>(string strsql, params object[] parameters)
        {
            try
            {
                SqlConnection connection =this.connectionPool.GetConnection();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = strsql;
                    command.Connection = connection;
                    if (parameters != null)
                    {
                        command.AddParams(parameters);
                    }
                    return command.ExecuteReader().DataReaderToModel<TEntity>();
                }
                
            }
            catch (Exception ex)
            {
                base.logger.Error("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
                throw new QuickAppException("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
            }
        }

        public override IEnumerable<TEntity> FindAll<TEntity>(string strsql, params object[] parameters)
        {
            try
            {
                SqlConnection connection =this.connectionPool.GetConnection();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = strsql;
                    command.Connection = connection;
                    if (parameters != null)
                    {
                        command.AddParams(parameters);
                    }
                    return command.ExecuteReader().DataReaderToList<TEntity>();
                }
            }
            catch (Exception ex)
            {
                base.logger.Error("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
                throw new QuickAppException("执行Sql语句失败，语句：" + strsql + "，原因：" + ex.Message);
            }
        }

        protected override void dispose()
        {
            
        }

    }
}
