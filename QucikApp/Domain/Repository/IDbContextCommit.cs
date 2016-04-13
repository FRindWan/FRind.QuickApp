/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/11 星期一 10:47:48
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="IDbContextCommit"/>
    /// </summary>
    public interface IDbContextCommit
    {
        int SaveChanges();
    }
}
