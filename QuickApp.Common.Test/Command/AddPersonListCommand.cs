/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 10:43:47
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Command
{
    /// <summary>
    /// <see cref="AddPersonListCommand"/>
    /// </summary>
    public class AddPersonListCommand:Commands.Command
    {
        public AddPersonListCommand(IList<PersonInfo> personInfoList)
        {
            this.PersonInfoList = personInfoList;
        }

        public IList<PersonInfo> PersonInfoList { get; set; }
    }
}
