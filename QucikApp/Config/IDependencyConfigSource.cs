/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:52:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Config
{
    /// <summary>
    /// <see cref="IDependencyConfigSource"/>
    /// </summary>
    public interface IDependencyConfigSource
    {
        bool EnableInterceptor { get; set; }
    }
}
