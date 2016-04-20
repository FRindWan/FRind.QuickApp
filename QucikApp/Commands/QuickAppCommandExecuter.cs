/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 15:43:44
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Commands
{
    /// <summary>
    /// <see cref="QuickAppCommandExecuter"/>
    /// </summary>
    public class QuickAppCommandExecuter:CommandExecuter
    {
        public static readonly QuickAppCommandExecuter Instance=new QuickAppCommandExecuter();

    }
}
