/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 15:52:41
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Commands;
using QuickApp.Common.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Command
{
    /// <summary>
    /// <see cref="AddPersonCommand"/>
    /// </summary>
    public class AddPersonCommand:Commands.Command
    {
        public PersonInfo PersonInfo { get; set; }
    }
}
