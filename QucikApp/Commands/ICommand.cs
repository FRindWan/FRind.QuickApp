/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 14:35:15
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Commands
{
    /// <summary>
    /// <see cref="ICommand"/>
    /// </summary>
    public interface ICommand
    {
        Guid CommandId { get; }

        DateTime CommandDate { get; }
    }
}
