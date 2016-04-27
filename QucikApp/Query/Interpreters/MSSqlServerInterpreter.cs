using QuickApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Query.Interpreters
{
    public class MSSqlServerInterpreter:Interpreter
    {
        public MSSqlServerInterpreter()
        { 
        
        }

        protected override string DoInterpreter(QueryBuilder queryBuilder)
        {
            if (queryBuilder.PageNumber > 0 && queryBuilder.PageSize > 0)
            {
                return GetPageSql(queryBuilder);
            }

            //{0}  需要插入的Top信息   
            //{1}  需要插入的查询列信息
            //{2}  需要插入的表信息
            //{3}  需要插入的表连接信息
            //{4}  需要插入的条件信息
            //{5}  需要插入的排序信息
            return string.Format("select {0} {1} {2} from {3} {4} {5} {6}","",
                BuildCount(queryBuilder),BuildColumns(queryBuilder),BuildTable(queryBuilder),"",BuildWhere(queryBuilder),BuildOrder(queryBuilder));

        }

        protected string GetTopInfo(QueryBuilder queryBuilder)
        {
            return null;
        }

        protected string GetPageSql(QueryBuilder queryBuilder)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("SELECT * FROM (SELECT ROW_NUMBER() OVER ({0}) AS Row, {1} FROM {2}  {3} ) AS Paged  WHERE {4}",
                BuildOrder(queryBuilder), BuildColumns(queryBuilder), BuildTable(queryBuilder), BuildWhere(queryBuilder),BuildPaged(queryBuilder));

            return sqlBuilder.ToString();
            
        }

        protected string BuildOrder(QueryBuilder queryBuilder)
        {
            StringBuilder stringBuilder = new StringBuilder("Order By ");
            if (queryBuilder.OrderByAsc.Count <= 0 && queryBuilder.OrderByDesc.Count <= 0)
            {
                return "";
            }

            if (queryBuilder.OrderByAsc != null && queryBuilder.OrderByAsc.Count > 0)
            {
                foreach (string orderby in queryBuilder.OrderByAsc)
                {
                    stringBuilder.AppendFormat("{0} asc,",orderby);
                }
            }
            if (queryBuilder.OrderByDesc != null && queryBuilder.OrderByDesc.Count > 0)
            {
                foreach (string orderby in queryBuilder.OrderByDesc)
                {
                    stringBuilder.AppendFormat("{0} desc,", orderby);
                }
            }

            return stringBuilder.Remove(stringBuilder.Length - 1,1).ToString();
        }

        protected string BuildColumns(QueryBuilder queryBuilder)
        {
            if (queryBuilder.SelectColumns == null || queryBuilder.SelectColumns.Count <= 0)
            {
                if (string.IsNullOrWhiteSpace(BuildCount(queryBuilder)))
                {
                    return "*";
                }
                else
                {
                    return "";
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string column in queryBuilder.SelectColumns)
            {
                stringBuilder.AppendFormat("{0},", column);
            }

            return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
        }

        protected string BuildTable(QueryBuilder queryBuilder)
        {
            if (queryBuilder.TableName == null || queryBuilder.TableName.Count <= 0)
            {
                throw new QueryInterpreterException("没有设置Table 无法生成语句！");
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (String tableItem in queryBuilder.TableName)
            {
                stringBuilder.AppendFormat("{0},", tableItem);
            }

            return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
        }

        protected string BuildWhere(QueryBuilder queryBuilder)
        {
            if (string.IsNullOrWhiteSpace(queryBuilder.Where))
            {
                return queryBuilder.Where;
            }
            else
            {
                return string.Format("where {0}", queryBuilder.Where);
            }
        }

        protected string BuildPaged(QueryBuilder QueryBuilder)
        {
            int rowStart = (QueryBuilder.PageNumber - 1) * QueryBuilder.PageSize;
            int rowEnd = QueryBuilder.PageNumber * QueryBuilder.PageSize;

            return string.Format("Row > {0} AND Row <={1}", rowStart, rowEnd);
        }

        protected string BuildCount(QueryBuilder queryBuilder)
        {
            if (queryBuilder.CountList == null || queryBuilder.CountList.Count <= 0)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder("");
            foreach (String count in queryBuilder.CountList)
            {
                if (count.Equals("*"))
                {
                    stringBuilder.AppendFormat("count({0}),", count);
                }
                else
                {
                    stringBuilder.AppendFormat("count({0}) as {1},", count, count);
                }
            }

            return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
        }
    }
}
