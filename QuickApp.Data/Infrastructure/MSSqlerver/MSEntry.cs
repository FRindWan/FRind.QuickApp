using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Data.Extensions;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using AiThinker.AiExpression;
using A4c.Extensions;
using QuickApp.Exceptions;

namespace QuickApp.Data.Infrastructure.MSSqlerver
{
    public class MSEntry:Entry
    {
        private readonly IDbFactory dbFactory;
        private readonly string insertSql;
        private readonly string updateSql;
        private readonly string deleteSql;

        public MSEntry(IDbFactory dbFactory, Type entityType):base(entityType)
        {
            this.dbFactory = dbFactory;
            this.getKeyForDb();
            this.insertSql = this.EntityType.BuildCreateSql(this.tableName);
            this.updateSql = this.EntityType.BuildUpdateSql(this.Keys, this.tableName);
            this.deleteSql = this.EntityType.BuildDeleteSql(this.Keys, this.tableName);
        }
        
        protected override bool Add(object entity)
        {
            if (entity.GetType() != this.EntityType || entity == null)
                throw new QuickAppException("执行实体 " + EntityType.Name + "添加操作失败，传入的实体为空！");

            IDictionary<string, object> columns = SqlExtension.GetPropertyKeyValueList(entity);

            IList<object> valueList = columns.Values.ToList();
            for (int i = 0; i < valueList.Count; i++)
            {
                object value = valueList[i];
                if (value == null)
                {
                    continue;
                }
                Type valueType = value.GetType();
                if (valueType.IsClass && valueType.IsGenericType)
                {
                    valueList.Remove(value);
                    continue;
                }
            }

            bool result = this.dbFactory.ExecuteSql(this.insertSql, valueList.ToArray());
            if (!result)
                throw new QuickAppException("执行实体 " + EntityType.Name + "添加操作失败，请查看数据日志！");

            return result;

        }

        protected override bool Update(object entity)
        {
            if (entity.GetType() != this.EntityType || entity == null)
                throw new QuickAppException("执行实体 " + EntityType.Name + "修改操作失败，传入的实体为空！");

            string[] updateSql = Regex.Split(this.updateSql, "where", RegexOptions.IgnoreCase);

            IDictionary<string, object> columns = SqlExtension.GetPropertyKeyValueList(entity);
            IList<Object> keyValues = new List<Object>();
            IList<Object> valueList = new List<Object>();
            foreach (KeyValuePair<String, Object> column in columns)
            {
                if (column.Value == null)
                {
                    continue;
                }

                Type valueType = column.Value.GetType();
                if (valueType.IsClass && valueType.IsGenericType)
                    continue;

                if (this.Keys.Contains(column.Key))
                    keyValues.Add(column.Value);

                valueList.Add(column.Value);
            }

            updateSql[1] = String.Format(updateSql[1], keyValues.ToArray());

            bool result = this.dbFactory.ExecuteSql(updateSql[0] + " where " + updateSql[1], valueList.ToArray());
            if (!result)
                throw new QuickAppException("执行实体 " + EntityType.Name + "修改操作失败，请查看数据日志！");

            return result;
        }

        protected override bool Delete(object entity)
        {
            if (entity.GetType() != this.EntityType || entity == null)
                throw new QuickAppException("执行实体 " + EntityType.Name + "删除操作失败，传入的实体为空！");

            IDictionary<string, object> columns = SqlExtension.GetPropertyKeyValueList(entity);
            IList<Object> keyValues = new List<Object>();
            foreach (String key in this.Keys)
            {
                keyValues.Add(columns[key]);
            }

            bool result = this.dbFactory.ExecuteSql(this.deleteSql, keyValues.ToArray());
            if (!result)
                throw new QuickAppException("执行实体 " + EntityType.Name + "删除操作失败，请查看数据日志！");

            return result;
        }

        public override TEntity Find<TEntity>(params object[] ids)
        {
            int count = 0;
            if (ids.Length >= this.Keys.Count)
                count = this.Keys.Count;
            else if (ids.Length < this.Keys.Count)
                count = ids.Length;

            StringBuilder strSelectSql = new StringBuilder();
            Object[] keyValues = new Object[count];
            strSelectSql.AppendFormat("select * from {0} where 1=1 ", this.tableName);
            for (int i = 0; i < count; i++)
            {
                strSelectSql.AppendFormat(" and {0}=@{1}", this.Keys[i], i);
                keyValues[i] = ids[i];
            }

            String strsql = DataFilterExtension.CreateSqlWhereForDataFilter(strSelectSql.ToString(), typeof(TEntity));

            this.dbFactory.Find<TEntity>(strsql, keyValues);

            return default(TEntity);
        }

        public override TEntity FindForSql<TEntity>(string strsql) 
        {
            if (String.IsNullOrWhiteSpace(strsql))
                return null;

            return this.dbFactory.Find<TEntity>(strsql);
        }

        public override IEnumerable<TEntity> FindAll<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate) 
        {
            AiExpConditions<TEntity> expc = new AiExpConditions<TEntity>();
            expc.AddAndWhere(predicate);

            String strsql = DataFilterExtension.CreateSqlWhereForDataFilter(String.Format("select * from {0} {1}", this.tableName, expc.Where()), typeof(TEntity));

            return this.dbFactory.FindAll<TEntity>(strsql);

        }

        public override IEnumerable<TEntity> FindAllForSql<TEntity>(string strsql) 
        {
            return this.dbFactory.FindAll<TEntity>(strsql);
        }

        #region Private Method

        private void getKeyForDb()
        {
            IList<String> keys = new List<String>();
            foreach (DataRow dataRow in this.dbFactory.ExecuteDataTable("select COLUMN_NAME as ColumnName from INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME='" + this.EntityType.Name + "'", null).Rows)
                keys.Add(dataRow[0].ToString().ToLower());
            this.keys = keys;
        }

        




        #endregion
    }
}
