/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 17:09:32
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Dependency
{
    /// <summary>
    /// <see cref="DependencyFactory"/>
    /// </summary>
    internal class DependencyFactory
    {
        internal static readonly IDependency dependency;

        static DependencyFactory()
        {
            DependencyFactory.dependency = new AutofacDependency();
        }

        internal static IDependency GetDependency()
        {
            return DependencyFactory.dependency;
        }
    }
}
