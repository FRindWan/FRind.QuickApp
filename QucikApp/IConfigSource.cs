/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:57:12
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Config;
using QuickApp.Config;
using QuickApp.Dependency;
using QuickApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp
{
    /// <summary>
    /// <see cref="IConfigSource"/>
    /// </summary>
    public interface IConfigSource
    {
        IDependencyConfigSource DependencyConfigSource { get; }

        IEventConfigSource EventConfigSource { get; }

        ICommandConfigSource CommandConfigSource { get; }

        Common.Config.IRepositoryConfigSource RepositoryConfigSource { get; }

        Common.Config.IWebConfigSource WebConfigSource { get; }

        IDependencyResolver DependencyResolver { get; }

        IConfigSource AddDependInitialize(DependencyInitialize dependencyInitialize);

        IConfigSource AddCommandScanAssembly(params Assembly[] assemblys);

        IConfigSource SetDbInfo(Type dbContextType,Type dbContextImplType, DataBaseType dbType);

        IQuickApp Initialize();
    }
}
