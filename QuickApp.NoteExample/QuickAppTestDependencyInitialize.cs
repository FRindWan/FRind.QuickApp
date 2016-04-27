/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 17:25:21
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Dependency;
using QuickApp.Domain.Repository;
using QuickApp.Common.Test.Application;
using QuickApp.Common.Test.Application.impl;
using QuickApp.Common.Test.Domain.Reposities;
using QuickApp.Common.Test.Domain.Reposities.impl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Common.Test.Command;
using QuickApp.Common.Test.SqlReposities;
using QuickApp.Data.Infrastructure;
using QuickApp.Common.Test.Domain.SqlReposities;

namespace QuickApp.Test
{
    /// <summary>
    /// <see cref="QuickAppTestDependencyInitialize"/>
    /// </summary>
    public class QuickAppTestDependencyInitialize:DependencyInitialize
    {

        public override void InitializeDependency(IDependencyRegister dependency)
        {
            //dependency.Register<DbContext, EFDbContext>();
            //dependency.Register<IRepositoryContext, EFRepositoryContext>();
            //dependency.Register<IPersonInfoRepository, PersonInfoRepository>();
            dependency.Register<IRepositoryContext, QuickApp.Data.QuickDataRepositoryContext>();
            dependency.Register<IPersonInfoRepository, SqlPersonInfoRepository>();
            dependency.Register<IPersonInfoApplication, PersonInfoApplication>();
            dependency.Register<PersonInfoCommandHandler>();

        }

        public override void InitializeInterceptor(QuickApp.Dependency.Autofac.RegisterInterceptorService registerInterceptorService)
        {
            
        }
    }
}
