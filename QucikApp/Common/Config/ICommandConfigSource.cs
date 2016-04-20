/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 15:26:05
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Config
{
    /// <summary>
    /// <see cref="ICommandConfigSource"/>
    /// </summary>
    public interface ICommandConfigSource
    {
        Assembly[] Assemblys { get; set; }

        void SetAssembly(params Assembly[] assemblys);
    }
}
