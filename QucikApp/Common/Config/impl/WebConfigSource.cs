/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 11:53:03
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Config.impl
{
    /// <summary>
    /// <see cref="WebConfigSource"/>
    /// </summary>
    public class WebConfigSource:IWebConfigSource
    {
        public System.Reflection.Assembly[] MvcControllerRegisterAssemblys { get; set; }

        public void AddMvcControllerRegisterAssembly(params System.Reflection.Assembly[] assemblys) 
        {
            if (assemblys == null || assemblys.Length <= 0)
            {
                throw new ConfigSourceException("当前配置的MVC 控制器程序集不合法，请检查！");
            }

            this.MvcControllerRegisterAssemblys = assemblys;
        }
    }
}
