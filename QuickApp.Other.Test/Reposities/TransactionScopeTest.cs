/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 11:47:46
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuickApp.Other.Test.Reposities
{
    /// <summary>
    /// <see cref="TransactionScopeTest"/>
    /// </summary>
    [TestClass]
    public class TransactionScopeTest
    {
        [TestMethod]
        public void TestTransactionScope()
        {
            SqlHelper sqlHelper1 = new SqlHelper("Server=(local);DataBase=QuickAppTest1;uid=sa;pwd=aaaa1111!");
            SqlHelper sqlHelper2 = new SqlHelper("Server=(local);DataBase=QuickAppTest2;uid=sa;pwd=aaaa1111!");

            try
            {
                TransactionScope transaction = new TransactionScope();

                int flag1=sqlHelper1.ExecutionSql("insert into Person (Name,Age) values ('FRind',21);");
                int flag2=sqlHelper2.ExecutionSql("insert into Person (Name,Age) values ('FRind',21);");

                transaction.Complete();

                if (flag1 <= 0 || flag2 <= 0)
                {
                    Assert.Fail("执行失败！");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }

    public class SqlHelper
    {
        private SqlConnection sqlConnection;

        public SqlHelper(String connectString)
        {
            sqlConnection = new SqlConnection(connectString);
        }

        public void Open()
        {
            switch (sqlConnection.State)
            {
                case ConnectionState.Broken:
                    sqlConnection.Close();
                    sqlConnection.Open();
                    break;
                case ConnectionState.Closed:
                    sqlConnection.Open();
                    break;
            }
        }

        public DataSet GetDataSet(string SqlString)
        {
            DataSet ds = new DataSet();
            Open();
            SqlDataAdapter da = new SqlDataAdapter(SqlString, sqlConnection);
            da.Fill(ds);
            return ds;
        }
        public DataTable GetDataTable(string SqlString)
        {
            DataSet ds = GetDataSet(SqlString);
            if (ds == null)
                return null;

            return ds.Tables[0];
        }
        public DataRow GetDataRow(string SqlString)
        {
            DataTable dt = GetDataSet(SqlString).Tables[0];
            if (dt == null || dt.Rows.Count <= 0)
                return null;

            return dt.Rows[0];
        }

        public Object GetResult(String SqlString)
        {
            DataRow dataRow =GetDataRow(SqlString);
            if (dataRow == null)
                return null;

            return dataRow[0];
        }

        public object ExecuteScalar(string SqlString)
        {
            object result = new object();
            Open();
            using (SqlCommand command = new SqlCommand(SqlString, sqlConnection))
            {
                result = command.ExecuteScalar();
            }
            return result;
        }

        public int ExecutionSql(string SqlString)
        {
            int flag = 0;
            try
            {
                Open();
                SqlCommand command = new SqlCommand(SqlString, sqlConnection);
                flag = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                flag = -1;
            }
            return flag;
        }
        public int ExecutionSqlArr(string[] SqlString)//处理多条数据
        {
            int flag = 0;
            try
            {
                Open();
                SqlCommand command = new SqlCommand();
                for (int i = 0; i < SqlString.Length; i++)
                {
                    if (SqlString[i] == "")
                        continue;
                    command.Connection = sqlConnection;
                    command.CommandText = SqlString[i].ToString();
                    flag = flag + command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                flag = -1;
            }
            return flag;
        }
    }
}
