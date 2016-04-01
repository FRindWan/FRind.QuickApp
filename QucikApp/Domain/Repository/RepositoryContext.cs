/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:33:13
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

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
        private PendingToDbObjectContainer pendingToDbObjectContainer;

        public RepositoryContext()
        {
            this.pendingToDbObjectContainer = new PendingToDbObjectContainer();
        }

        public void AppendAdd<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Add);
        }

        public void AppendAdd(object aggregateRootEntity)
        {
            this.pendingToDbObjectContainer.Append(aggregateRootEntity, PendingToDbOperatorType.Add);
        }

        public void AppendUpdate<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Update);
        }

        public void AppendUpdate(object aggregateRootEntity)
        {
            this.pendingToDbObjectContainer.Append(aggregateRootEntity, PendingToDbOperatorType.Update);
        }

        public void AppendDelete<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Delete);
        }

        public void AppendDelete(object aggregateRoot)
        {
            this.pendingToDbObjectContainer.Append(aggregateRoot, PendingToDbOperatorType.Delete);
        }

        public void Dispose()
        {
            this.pendingToDbObjectContainer.Clear();
            this.pendingToDbObjectContainer = null;

            this.DoDispose();
        }

        public void SaveChanges()
        {
            this.DoSaveChanges();
        }

        protected abstract void DoDispose();

        protected abstract void DoSaveChanges();
    }
}
