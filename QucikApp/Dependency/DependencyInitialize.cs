/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:56:53
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency.Interceptors;
using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Dependency
{
    /// <summary>
    /// <see cref="DependencyInitialize"/>
    /// </summary>
    public class DependencyInitializeService
    {
        private static IList<DependencyInitialize> dependencyInitializes;

        static DependencyInitializeService()
        {
            dependencyInitializes = new List<DependencyInitialize>();
        }

        public static void Initialize()
        {
            IDependency dependency = DependencyFactory.GetDependency();

            for (int i = dependencyInitializes.Count - 1; i >= 0;i-- )
            {
                dependencyInitializes[i].InitializeInterceptor(RegisterInterceptorService.Instance);
                dependencyInitializes[i].InitializeDependency(dependency);
            }
        }

        public static void AddDependencyInitialize(DependencyInitialize dependencyInitialize)
        {
            dependencyInitializes.Add(dependencyInitialize);
        }
    }

    public abstract class DependencyInitialize
    {
        public abstract void InitializeInterceptor(RegisterInterceptorService registerInterceptorService);

        public abstract void InitializeDependency(IDependency dependency);
    }
}
