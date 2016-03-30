/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:51:49
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp
{
    /// <summary>
    /// <see cref="IQuickApp"/>
    /// </summary>
    public interface IQuickApp
    {
        IConfigSource ConfigSource { get; }

        IDependency DependencyContainer { get; }

        void Initialize();
    }
}
