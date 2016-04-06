/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:33:13
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Data;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="RepositoryContext"/>
    /// </summary>
    public abstract class RepositoryContext : IRepositoryContextCommit
    {
        protected readonly PendingToDbObjectContainer pendingToDbObjectContainer;
        protected readonly IDataContext dataContext;

        public RepositoryContext(IDataContext dataContext)
        {
            this.dataContext = dataContext;
            this.pendingToDbObjectContainer = new PendingToDbObjectContainer();
        }

        public virtual void AppendAdd<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Add);
        }

        public virtual void AppendAdd(object aggregateRootEntity)
        {
            this.pendingToDbObjectContainer.Append(aggregateRootEntity, PendingToDbOperatorType.Add);
        }

        public virtual void AppendUpdate<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Update);
        }

        public virtual void AppendUpdate(object aggregateRootEntity)
        {
            this.pendingToDbObjectContainer.Append(aggregateRootEntity, PendingToDbOperatorType.Update);
        }

        public virtual void AppendDelete<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Delete);
        }

        public virtual void AppendDelete(object aggregateRoot)
        {
            this.pendingToDbObjectContainer.Append(aggregateRoot, PendingToDbOperatorType.Delete);
        }

        public virtual void Dispose()
        {
            this.pendingToDbObjectContainer.Clear();

            this.DoDispose();
        }

        public virtual void SaveChanges()
        {
            foreach (Object obj in this.pendingToDbObjectContainer.GetPendingToDbList(PendingToDbOperatorType.Add))
            {
                this.dataContext.Add(obj);
            }

            this.pendingToDbObjectContainer.Clear();
        }

        protected abstract void DoDispose();
    }
}
