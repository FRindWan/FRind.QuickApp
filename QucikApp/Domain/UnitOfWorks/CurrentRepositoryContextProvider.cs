/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 15:29:11
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using QucikApp.Domain.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="CurrentRepositoryContextProvider"/>
    /// </summary>
    public class CurrentRepositoryContextProvider:ICurrentRepositoryContextProvider
    {
        private String ContextKey = "QuickApp.RepositoryContext.Current";
        private IDependencyResolver dependencyResolver;

        private static readonly ConcurrentDictionary<string, IRepositoryContext> repositoryContextDictionary = new ConcurrentDictionary<string, IRepositoryContext>();

        public CurrentRepositoryContextProvider()
        {
            this.dependencyResolver = DependencyFactory.GetDependency();
        }

        public IRepositoryContext GetCurrentRepositoryContext()
        {
            String repositoryContextKey = CallContext.LogicalGetData(this.ContextKey) as string;
            if (String.IsNullOrWhiteSpace(repositoryContextKey))
            {
                CallContext.FreeNamedDataSlot(this.ContextKey);
                return null;
            }

            IRepositoryContext repositoryContext;
            if (!repositoryContextDictionary.TryGetValue(repositoryContextKey, out repositoryContext))
            {
                CallContext.FreeNamedDataSlot(this.ContextKey);
                return null;
            }

            if (repositoryContext.IsDisposed)
            {
                CallContext.FreeNamedDataSlot(this.ContextKey);
                repositoryContextDictionary.TryRemove(repositoryContextKey, out repositoryContext);
                return null;
            }

            return repositoryContext;
        }

        public void SetCurrentRepositoryContext(IRepositoryContext repositoryContext)
        {
            if (repositoryContext == null || repositoryContext.IsDisposed)
                return;

            if (!repositoryContextDictionary.TryAdd(repositoryContext.Id.ToString(), repositoryContext))
            {
                return;
            }

            CallContext.LogicalSetData(this.ContextKey, repositoryContext.Id.ToString());
        }

        public IRepositoryContext Current
        {
            get 
            {
                IRepositoryContext repositoryContext = this.GetCurrentRepositoryContext();
                if (repositoryContext == null)
                {
                    repositoryContext=this.dependencyResolver.Resolver<IRepositoryContext>();
                    this.SetCurrentRepositoryContext(repositoryContext);
                }

                return repositoryContext;
            }
            set 
            { 
                this.SetCurrentRepositoryContext(value); 
            }
        }
    }
}
