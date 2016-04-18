/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:20:54
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Dependency
{
    /// <summary>
    /// <see cref="IDependency"/>
    /// </summary>
    public interface IDependency:IDependencyRegister,IDependencyResolver,IDisposable
    {

    }
}
