/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:22:59
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Config;
using QuickApp.Data.Infrastructure;
using QuickApp.Dependency;
using QuickApp.Domain.Repository;
using QuickApp.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data
{
    /// <summary>
    /// <see cref="QuickAppDataDependInitialize"/>
    /// </summary>
    public class QuickAppDataDependInitialize:DependencyInitialize
    {
        public override void InitializeInterceptor(Dependency.Autofac.RegisterInterceptorService registerInterceptorService)
        {
            
        }

        public override void InitializeDependency(IDependencyRegister dependency)
        {
            dependency.Register<IRepositoryContext, QuickApp.Data.QuickDataRepositoryContext>();
            dependency.Register<IQuery, QuickApp.Data.QuickDataQuery>();
        }
    }
}
