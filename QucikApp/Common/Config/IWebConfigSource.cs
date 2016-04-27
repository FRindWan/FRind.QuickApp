/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 11:51:33
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
    /// <see cref="IWebConfigSource"/>
    /// </summary>
    public interface IWebConfigSource
    {
        Assembly[] MvcControllerRegisterAssemblys { get; set; }

        void AddMvcControllerRegisterAssembly(params Assembly[] assemblys);
    }
}
