/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 14:40:21
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Exceptions
{
    /// <summary>
    /// <see cref="CommandException"/>
    /// </summary>
    public class CommandException:QuickAppException
    {
        public CommandException(String message)
            : base(message)
        { 
        
        }
    }
}
