/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:23:38
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Dependency
{
    /// <summary>
    /// <see cref="DependencyLifeTime"/>
    /// </summary>
    public enum DependencyLifeTime
    {
        Transient,
        Singleton,
        WebRequest
    }
}
