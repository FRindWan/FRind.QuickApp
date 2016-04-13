/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:11:14
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.EntityFramework.Repository
{
    /// <summary>
    /// <see cref="IEFRepositoryContext"/>
    /// </summary>
    public interface IEFRepositoryContext:IRepositoryContext
    {
        DbContext Context { get; }
    }
}
