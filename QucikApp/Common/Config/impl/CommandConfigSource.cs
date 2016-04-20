/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 15:26:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Config.impl
{
    /// <summary>
    /// <see cref="CommandConfigSource"/>
    /// </summary>
    public class CommandConfigSource:ICommandConfigSource
    {
        public System.Reflection.Assembly[] Assemblys { get; set; }

        public void SetAssembly(params System.Reflection.Assembly[] assemblys)
        {
            this.Assemblys = assemblys;
        }
    }
}
