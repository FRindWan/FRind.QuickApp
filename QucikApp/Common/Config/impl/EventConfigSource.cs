/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 14:46:24
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Config.impl
{
    /// <summary>
    /// <see cref="EventConfigSource"/>
    /// </summary>
    public class EventConfigSource:IEventConfigSource
    {
        public System.Reflection.Assembly[] Assemblys { get; set; }

        public void SetAssembly(params Assembly[] assemblys)
        {
            this.Assemblys = assemblys;
        }
    }
}
