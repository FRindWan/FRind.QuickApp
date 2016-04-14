/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 11:26:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Castle.DynamicProxy;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="ApplicationInterceptor"/>
    /// </summary>
    public class ApplicationInterceptor : IInterceptor
    {
        private ICurrentRepositoryContextProvider repositoryContextProvider;

        public ApplicationInterceptor(ICurrentRepositoryContextProvider repositoryContextProvider)
        {
            this.repositoryContextProvider = repositoryContextProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            this.repositoryContextProvider.Current.Commit();
        }
    }
}
