/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 17:08:31
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Application;
using QuickApp.Commands;
using QuickApp.Config;
using QuickApp.Config.impl;
using QuickApp.Dependency;
using QuickApp.Dependency.Autofac;
using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using QuickApp.Eventing;
using QuickApp.Eventing.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp
{
    /// <summary>
    /// <see cref="QuickAppDependencyInitialize"/>
    /// </summary>
    internal class QuickAppDependencyInitialize:DependencyInitialize
    {
        public override void InitializeInterceptor(RegisterInterceptorService registerInterceptorService)
        {
            registerInterceptorService.AddAutofacRegisterInterceptor(new ApplicationInterceptorRegister());
        }

        public override void InitializeDependency(IDependencyRegister dependency)
        {
            this.RegisterDb(dependency);

            dependency.Register<IConfigSource, ConfigSource>(DependencyLifeTime.Singleton);
            dependency.Register<IDependencyConfigSource, DependencyConfigSource>(DependencyLifeTime.Singleton);

            dependency.Register<IRepositoryContextManager, RepositoryContextManager>();
            dependency.Register<ICurrentRepositoryContextProvider, CurrentRepositoryContextProvider>();

            dependency.Register<IEventBus, EventBus>(DependencyLifeTime.Singleton);
            dependency.Register<IEventAggregator, EventAggregator>(DependencyLifeTime.Singleton);

            if (ConfigSource.Instance.DependencyConfigSource.EnableInterceptor)
            {
                dependency.Register<ApplicationInterceptor>();
            }
        }

        private void RegisterDb(IDependencyRegister dependency)
        {
            if (ConfigSource.Instance.RepositoryConfigSource.DbContextImplType == null || ConfigSource.Instance.RepositoryConfigSource.DbContextType == null)
            {
                return;
            }

            dependency.Register(ConfigSource.Instance.RepositoryConfigSource.DbContextType
                ,ConfigSource.Instance.RepositoryConfigSource.DbContextImplType
                , DependencyLifeTime.Singleton);
        }
    }
}
