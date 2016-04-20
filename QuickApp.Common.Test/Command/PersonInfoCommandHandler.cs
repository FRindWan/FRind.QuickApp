/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 17:02:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Command
{
    /// <summary>
    /// <see cref="PersonInfoCommandHandler"/>
    /// </summary>
    public class PersonInfoCommandHandler
    {
        public void AddPersonInfo(AddPersonCommand addPersonCommand)
        {
            Console.WriteLine(addPersonCommand.PersonInfo.UserName);
        }
    }
}
