/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 12:04:58
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using QucikApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="RepositoryContextManager"/>
    /// </summary>
    public class RepositoryContextManager:IRepositoryContextManager
    {
        private ICurrentRepositoryContextProvider currentRepositoryContextProvider;
        private IDependencyResolver dependencyResolver;

        public RepositoryContextManager(ICurrentRepositoryContextProvider currentRepositoryContextProvider)
        {
            this.currentRepositoryContextProvider = currentRepositoryContextProvider;
            this.dependencyResolver = DependencyFactory.GetDependency();
        }

        public IRepositoryContext Create()
        {
            return this.currentRepositoryContextProvider.Current ;
        }
    }
}
