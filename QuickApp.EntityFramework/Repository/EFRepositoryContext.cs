/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 12:28:53
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.EntityFramework.Repository
{
    /// <summary>
    /// <see cref="EFRepositoryContext"/>
    /// </summary>
    public class EFRepositoryContext:RepositoryContext
    {
        protected override void DoDispose()
        {
            throw new NotImplementedException();
        }

        protected override void DoSaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
