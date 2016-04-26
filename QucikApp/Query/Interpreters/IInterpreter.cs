/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 18:25:31
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Query.Interpreters
{
    /// <summary>
    /// <see cref="IInterpreter"/>
    /// </summary>
    public interface IInterpreter
    {
        string InterpreterQueryBuilder(QueryBuilder queryBuilder, DataBaseType dbType);
    }
}
