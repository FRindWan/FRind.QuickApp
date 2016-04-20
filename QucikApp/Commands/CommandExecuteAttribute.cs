/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 14:49:21
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
    /// <see cref="CommandExecuteAttribute"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandExecuteAttribute:Attribute
    {
        public CommandExecuteAttribute(Type commandType)
        {
            this.CommandType = commandType;
        }

        public Type CommandType { get; private set; }
    }
}
