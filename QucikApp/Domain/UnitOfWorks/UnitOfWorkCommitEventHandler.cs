/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:13:55
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="UnitOfWorkCommitComplateEventHandler"/>
    /// </summary>
    public delegate void UnitOfWorkCommitComplateEventHandler(UnitOfWorkCommitComplateEventArgs args);

    /// <summary>
    /// <see cref="UnitOfWorkCommitErrorEventHandler"/>
    /// </summary>
    public delegate void UnitOfWorkCommitErrorEventHandler(UnitOfWorkCommitErrorEventArgs args);
}
