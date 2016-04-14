/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 17:08:31
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Config;
using QucikApp.Config.impl;
using QucikApp.Dependency;
using QucikApp.Dependency.Interceptors;
using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp
{
    /// <summary>
    /// <see cref="QuickAppDependencyInitialize"/>
    /// </summary>
    public class QuickAppDependencyInitialize:DependencyInitialize
    {
        public override void InitializeInterceptor(RegisterInterceptorService registerInterceptorService)
        {
            registerInterceptorService.AddAutofacRegisterInterceptor(new ApplicationInterceptorRegister());
        }

        public override void InitializeDependency(IDependency dependency)
        {
            dependency.Register<IConfigSource, ConfigSource>(DependencyLifeTime.Singleton);
            dependency.Register<IDependencyConfigSource, DependencyConfigSource>(DependencyLifeTime.Singleton);

            dependency.Register<IRepositoryContextManager, RepositoryContextManager>();
            dependency.Register<ICurrentRepositoryContextProvider, CurrentRepositoryContextProvider>();

            if (ConfigSource.Instance.DependencyConfigSource.EnableInterceptor)
            {
                dependency.Register<ApplicationInterceptor>();
            }
        }
    }
}
