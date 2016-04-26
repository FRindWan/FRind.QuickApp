using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Query
{
    public class QueryBuilder
    {
        private IList<string> selectColumns;
        private IList<string> tableName;
        private IList<string> where;
        private IList<string> innerJoin;
        private IList<string> orderByAsc;
        private IList<string> orderByDesc;

        public QueryBuilder()
        {
            this.selectColumns = new List<string>();
            this.tableName = new List<string>();
            this.where = new List<string>();
            this.innerJoin = new List<string>();
            this.orderByAsc = new List<string>();
            this.orderByDesc = new List<string>();
        }

        protected IList<string> SelectColumns { get { return this.selectColumns; } }

        protected IList<string> TableName { get { return this.tableName; } }

        protected IList<string> Where { get { return this.where; } }

        protected IList<string> InnerJoin { get { return this.innerJoin; } }

        protected IList<string> OrderByAsc { get { return this.orderByAsc; } }

        protected IList<string> OrderByDesc { get { return this.orderByDesc; } }

        public QueryBuilder FromTable(string tableName)
        {
            if (String.IsNullOrWhiteSpace(tableName))
            {
                return this;
            }

            this.tableName.Add(tableName);

            return this;
        }

        public QueryBuilder AddSelectColumn(string selectColumns)
        {
            if (String.IsNullOrWhiteSpace(selectColumns))
            {
                return this;
            }

            this.selectColumns.Add(selectColumns);

            return this;
        }

        public QueryBuilder AddWhere(string where)
        {
            if (String.IsNullOrWhiteSpace(where))
            {
                return this;
            }

            this.where.Add(where);

            return this;
        }

        public QueryBuilder AddInnerJoin(string tableName)
        {
            if (String.IsNullOrWhiteSpace(tableName))
            {
                return this;
            }

            this.innerJoin.Add(tableName);

            return this;
        }

        public QueryBuilder AddOrderByAsc(string columnName)
        {
            if (String.IsNullOrWhiteSpace(columnName))
            {
                return this;
            }

            this.orderByAsc.Add(columnName);

            return this;
        }

        public QueryBuilder AddOrderByDesc(string columnName)
        {
            if (String.IsNullOrWhiteSpace(columnName))
            {
                return this;
            }

            this.orderByDesc.Add(columnName);

            return this;
        }

        public override string ToString()
        {
            throw new NotImplementedException("该类不允许执行ToString方法！");
        }
        
    }
}
