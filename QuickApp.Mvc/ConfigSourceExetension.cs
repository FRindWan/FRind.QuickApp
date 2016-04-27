/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 11:47:44
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Mvc.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Mvc
{
    /// <summary>
    /// <see cref="ConfigSourceExetension"/>
    /// </summary>
    public static class ConfigSourceExetension
    {
        public static IConfigSource RegisterMvc(this IConfigSource configSource,params Assembly[] registerAssembly)
        {
            configSource.WebConfigSource.AddMvcControllerRegisterAssembly(registerAssembly);
            configSource.AddDependInitialize(new MvcDependencyInitialize());

            return configSource;
        }
    }
}
