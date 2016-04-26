/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 12:29:33
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Data.Infrastructure;
using QuickApp.Query;
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
        private 

        public QuickDataQuery(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Find<T>(QueryBuilder queryBuilder)
        {
            this.dbContext.
        }

        public IEnumerable<T> IQuery.Find<T>(QueryBuilder queryBuilder)
        {
            throw new NotImplementedException();
        }

        public QuickApp.Infrastructure.IPaged<T> IQuery.Find<T>(QueryBuilder queryBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
