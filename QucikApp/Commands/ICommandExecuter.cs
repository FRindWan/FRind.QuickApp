/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 15:27:17
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
    /// <see cref="ICommandExecuter"/>
    /// </summary>
    public interface ICommandExecuter
    {
        Object Execute(ICommand command);

        Task<Object> ExecuteAsync(ICommand command);
    }
}
