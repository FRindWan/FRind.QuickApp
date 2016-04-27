/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 12:29:33
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Data.Infrastructure;
using QuickApp.Exceptions;
using QuickApp.Infrastructure;
using QuickApp.Infrastructure.Pageds;
using QuickApp.Query;
using QuickApp.Query.Interpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data
{
    /// <summary>
    /// <see cref="QuickDataQuery"/>
    /// </summary>
    public class QuickDataQuery:IQuery
    {
        private SqlDbContext dbContext;
        private IInterpreter interperter;

        public QuickDataQuery(SqlDbContext dbContext, IInterpreter interperter)
        {
            this.dbContext = dbContext;
            this.interperter = interperter;
        }

        public T Find<T>(QueryBuilder queryBuilder)where T:class
        {
            IEntry entry = this.dbContext.GetEntry(typeof(T));
            queryBuilder = this.CheckTableNameAndAddDefaultTableName(entry, queryBuilder);

            return entry.FindForSql<T>(this.interperter.InterpreterQueryBuilder(queryBuilder));
        }

        public IEnumerable<T> FindAll<T>(QueryBuilder queryBuilder)where T:class
        {
            IEntry entry = this.dbContext.GetEntry(typeof(T));
            queryBuilder = this.CheckTableNameAndAddDefaultTableName(entry, queryBuilder);

            return entry.FindAllForSql<T>(this.interperter.InterpreterQueryBuilder(queryBuilder));
        }

        public IPaged<T> FindPaged<T>(QueryBuilder queryBuilder)where T:class
        {
            if (queryBuilder.PageSize <= 0 || queryBuilder.PageNumber <= 0)
            {
                throw new QuickAppException("查询分页信息，请传入PageSize和PageNumber！");
            }

            IEntry entry = this.dbContext.GetEntry(typeof(T));
            queryBuilder = this.CheckTableNameAndAddDefaultTableName(entry, queryBuilder);

            var data = entry.FindAllForSql<T>(this.interperter.InterpreterQueryBuilder(queryBuilder));
            QueryBuilder queryBuilderPageCount = new QueryBuilder();
            var counts =Convert.ToInt32(this.dbContext.Query(this.interperter.InterpreterQueryBuilder(queryBuilderPageCount.AddCount("*").FromTable(queryBuilder.TableName.ToArray()).AddWhere(queryBuilder.Where))));
            
            int pageCounts = 0;
            if (counts % queryBuilder.PageSize == 0)
                pageCounts = counts / queryBuilder.PageSize;
            else
                pageCounts = (counts / queryBuilder.PageSize) + 1;

            return new Paged<T>(pageCounts, queryBuilder.PageNumber, counts, queryBuilder.PageSize, data==null?new List<T>():data.ToList());

        }

        private QueryBuilder CheckTableNameAndAddDefaultTableName(IEntry entry,QueryBuilder queryBuilder)
        {
            if (queryBuilder.TableName == null || queryBuilder.TableName.Count <= 0)
            {
                queryBuilder.FromTable(entry.TableName);
            }

            return queryBuilder;
        }
    }
}
