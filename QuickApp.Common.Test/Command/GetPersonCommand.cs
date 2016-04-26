/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 10:38:38
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Command
{
    /// <summary>
    /// <see cref="GetPersonCommand"/>
    /// </summary>
    public class GetPersonCommand:Commands.Command
    {
        public GetPersonCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
