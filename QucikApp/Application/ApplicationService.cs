/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 18:26:43
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Application
{
    /// <summary>
    /// <see cref="ApplicationService"/>
    /// </summary>
    public class ApplicationService:IApplicationService
    {
        private IRepositoryContext repositoryContext;

        public ApplicationService()
        {
            this.repositoryContext = Dependency.DependencyFactory.GetDependency().Resolver<ICurrentRepositoryContextProvider>().Current;
        }

        protected IRepositoryContext RepositoryContext { get { return this.repositoryContext; } }

    }
}
