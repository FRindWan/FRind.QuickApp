/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 11:26:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Castle.DynamicProxy;
using QuickApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.Repository
{
    /// <summary>
    /// <see cref="RepositoryInterceptor"/>
    /// </summary>
    public class RepositoryInterceptor : IInterceptor
    {
        private ICurrentRepositoryContextProvider repositoryContextProvider;
        private IRepositoryContextManager repositoryContextManager;

        public RepositoryInterceptor(ICurrentRepositoryContextProvider repositoryContextProvider, IRepositoryContextManager repositoryContextManager)
        {
            this.repositoryContextManager = repositoryContextManager;
            this.repositoryContextProvider = repositoryContextProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            if (this.repositoryContextProvider.Current == null)
            {
                this.repositoryContextManager.Create();
            }

            invocation.Proceed();

            if (!this.repositoryContextProvider.Current.IsCommited)
            {
                this.repositoryContextProvider.Current.Commit();
            }
        }

        private void OnCommitError(UnitOfWorkCommitErrorEventArgs args)
        {
            throw args.UnitOfWorkException;
        }

    }
}
