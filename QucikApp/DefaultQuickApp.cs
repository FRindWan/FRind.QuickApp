/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 17:19:43
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Commands;
using QuickApp.Dependency;
using QuickApp.Dependency.Autofac;
using QuickApp.Dependency.Interceptors;
using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using QuickApp.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickApp
{
    /// <summary>
    /// <see cref="DefaultQuickApp"/>
    /// </summary>
    public class DefaultQuickApp:IQuickApp
    {
        private IConfigSource configSource;
        private IDependency dependency;

        public DefaultQuickApp()
        {
            this.dependency = DependencyFactory.GetDependency();
            this.configSource = Config.ConfigSource.Instance;
        }

        public IConfigSource ConfigSource
        {
            get { return this.configSource; }
        }

        public Dependency.IDependency DependencyContainer
        {
            get { return this.dependency; }
        }

        public void Initialize()
        {
            CommandInitializeService.Initialize();

            DependencyInitializeService.AddDependencyInitialize(new QuickAppDependencyInitialize());
            DependencyInitializeService.Initialize();

            //EventInitialize.Initialize(this.configSource.EventConfigSource.Assemblys);
        }
    }
}
