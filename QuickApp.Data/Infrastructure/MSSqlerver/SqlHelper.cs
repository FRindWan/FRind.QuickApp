using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Data.Extensions;
using System.Diagnostics;
using System.Configuration;

namespace QuickApp.Data.Infrastructure.MSSqlerver
{
    public class SqlHelper
    {
        #region 私有变量

        private int commandTimeOut = 0; //默认SQL执行超时时间

        private bool alreadyDisposed = false;//是否已经释放过资源

        private SqlConnection sqlConn;

        private SqlCommand sqlCmd;

        #endregion

        #region 构造函数

        public SqlHelper(string nameOrConnectString=null)
        {
            if (string.IsNullOrEmpty(nameOrConnectString))
            {
                nameOrConnectString = "name=Default";
            }

            if (nameOrConnectString.Contains("name="))
            {
                nameOrConnectString = ConfigurationManager.ConnectionStrings[nameOrConnectString.Split('=')[1]].ToString();
            }
            sqlConn = new SqlConnection(nameOrConnectString);
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (sqlCmd == null)
            {
                try
                {
                    if (sqlConn.State != ConnectionState.Open)
                        sqlConn.Open();
                }
                catch (Exception ex)
                { }

                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                if (commandTimeOut > 0)
                {
                    sqlCmd.CommandTimeout = commandTimeOut;
                }
            }

        }

        /// <summary>
        /// 关闭，内部释放资源
        /// </summary>
        public void Close()
        {
            ((IDisposable)this).Dispose();
        }

        private void Dispose(bool isDisposed)
        {
            if (alreadyDisposed)
            {
                return;
            }
            if (isDisposed)
            {
                if (sqlConn != null && sqlConn.State != ConnectionState.Closed)
                {
                    try
                    {
                        if (sqlCmd != null)
                        {
                            sqlCmd.Dispose();
                        }
                        sqlConn.Dispose();
                    }
                    catch (SqlException ex)
                    {
                        //Logger.Error("销毁对象异常", ex);
                        sqlConn = null;
                    }
                    alreadyDisposed = true;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~SqlHelper()
        {
#if !debug
            Dispose(false);
#endif
        }

        #endregion

        #region 外部公开方法

        public DataTable ExecuteSelect(string sql)
        {
            return ExecuteSelect(sql, null);
        }

        public DataTable ExecuteSelect(string sql, params object[] param)
        {
            Init();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = CommandType.Text;
                if (param != null)
                {
                    sqlCmd.AddParams(param);
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCmd;
                sqlDataAdapter.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                //Logger.Error("SQL错误.执行的SQL语句为:" + sql + ";参数:" + param.ToString(), ex);
                throw;
            }
            finally
            {
                sqlCmd.Parameters.Clear();
            }
            return null;
        }

        public int ExecuteNoQuery(string sql)
        {
            return ExecuteNoQuery(sql, null);
        }

        public int ExecuteNoQuery(string sql, params object[] param)
        {
            Init();
            int effectRows = 0;
            try
            {
                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = CommandType.Text;
                if (param != null)
                {
                    sqlCmd.AddParams(param);
                }
                effectRows = sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //Logger.Error("SQL错误.执行的SQL语句为:" + sql + ";参数:" + param.ToString(), ex);
                throw ex;
            }
            finally
            {
                sqlCmd.Parameters.Clear();
            }
            return effectRows;
        }

        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, null);
        }

        public SqlDataReader ExecuteReader(string sql, params object[] param)
        {
            Init();
            SqlDataReader dr;
            try
            {
                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = CommandType.Text;
                if (param != null)
                {
                    sqlCmd.AddParams(param);
                }
                Stopwatch watcher = new Stopwatch();
                watcher.Start();
                dr = sqlCmd.ExecuteReader();
                watcher.Stop();
                //Logger.Debug("查询SQL语句：" + sql + "\t\n;共耗时：" + watcher.ElapsedMilliseconds);
            }
            catch (SqlException ex)
            {
                //Logger.Error("SQL错误.执行的SQL语句为:" + sql + ";参数:" + param.ToString(), ex);
                throw;
            }
            finally
            {
                sqlCmd.Parameters.Clear();
            }
            return dr;
        }

        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null);
        }

        public object ExecuteScalar(string sql, params object[] param)
        {
            Init();
            try
            {
                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = CommandType.Text;
                if (param != null)
                {
                    sqlCmd.AddParams(param);
                }
                return sqlCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //Logger.Error("SQL错误.执行的SQL语句为:" + sql + ";参数:" + param.ToString(), ex);
                throw;
            }
            finally
            {
                sqlCmd.Parameters.Clear();
            }
        }

        public T Find<T>(string strsql)
        {
            return this.ExecuteReader(strsql).DataReaderToModel<T>();
        }

        public T Find<T>(string strsql, params object[] param)
        {
            return this.ExecuteReader(strsql, param).DataReaderToModel<T>();
        }

        public IList<T> FindAll<T>(string strsql)
        {
            return this.ExecuteReader(strsql).DataReaderToList<T>();
        }

        public IList<T> FindAll<T>(string strsql, params object[] param)
        {
            return this.ExecuteReader(strsql, param).DataReaderToList<T>();
        }

        #endregion
    }
}
