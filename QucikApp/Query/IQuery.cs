/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 12:20:11
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Query
{
    /// <summary>
    /// <see cref="IQuery"/>
    /// </summary>
    public interface IQuery
    {
        T Find<T>(QueryBuilder queryBuilder) where T : class;

        IEnumerable<T> FindAll<T>(QueryBuilder queryBuilder) where T : class;

        IPaged<T> FindPaged<T>(QueryBuilder queryBuilder) where T : class;
    }
}
