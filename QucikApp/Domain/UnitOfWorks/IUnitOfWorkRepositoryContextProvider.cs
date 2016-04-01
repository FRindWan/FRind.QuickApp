/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 11:54:50
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="IUnitOfWorkRepositoryContextProvider"/>
    /// </summary>
    public interface IUnitOfWorkRepositoryContextProvider<TContext>where TContext:IRepositoryContextCommit
    {
        TContext Context { get; }
    }
}
