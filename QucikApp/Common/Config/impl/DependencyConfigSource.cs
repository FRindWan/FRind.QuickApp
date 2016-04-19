/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:53:47
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Config.impl
{
    /// <summary>
    /// <see cref="DependencyConfigSource"/>
    /// </summary>
    public class DependencyConfigSource:IDependencyConfigSource
    {
        public DependencyConfigSource()
        {
            this.EnableInterceptor = true;
        }

        public bool EnableInterceptor { get; set; }
    }
}
