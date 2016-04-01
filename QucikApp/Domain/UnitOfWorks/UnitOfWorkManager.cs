/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 12:04:58
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="UnitOfWorkManager"/>
    /// </summary>
    public class UnitOfWorkManager:IUnitOfWorkManager
    {
        private ICurrentUnitOfWorkProvider currentUnitOfWorkProvider;
        private IDependencyResolver dependencyResolver;

        public UnitOfWorkManager(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider, IDependencyResolver dependencyResolver)
        {
            this.currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            this.dependencyResolver = dependencyResolver;
        }

        public IUnitOfWork Outer
        {
            get { return this.currentUnitOfWorkProvider.Current; }
        }

        public IUnitOfWork Create()
        {
            IUnitOfWork unitOfWork = this.dependencyResolver.Resolver<IUnitOfWork>();
            this.currentUnitOfWorkProvider.Current = unitOfWork;

            return unitOfWork;
        }
    }
}
