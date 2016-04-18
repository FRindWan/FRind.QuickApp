/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:12:20
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="UnitOfWorkCommitComplateEventArgs"/>
    /// </summary>
    public class UnitOfWorkCommitComplateEventArgs:EventArgs
    {
    }

    /// <summary>
    /// <see cref="UnitOfWorkCommitErrorEventArgs"/>
    /// </summary>
    public class UnitOfWorkCommitErrorEventArgs : EventArgs
    {
        public UnitOfWorkException UnitOfWorkException;

        public UnitOfWorkCommitErrorEventArgs(UnitOfWorkException unitOfWorkException)
        {
            this.UnitOfWorkException = unitOfWorkException;
        }
    }
}
