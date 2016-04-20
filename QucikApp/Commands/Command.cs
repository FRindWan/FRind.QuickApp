/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 14:26:49
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
    /// <see cref="Command"/>
    /// </summary>
    public abstract class Command:ICommand
    {
        public Command()
        {
            this.CommandId = Guid.NewGuid();
            this.CommandDate = DateTime.Now;
        }

        public Guid CommandId { get; private set; }

        public DateTime CommandDate { get; private set; }
    }
}
