/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 12:28:53
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Entites;
using QucikApp.Domain.Repository;
using QucikApp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.EntityFramework.Repository
{
    /// <summary>
    /// <see cref="EFRepositoryContext"/>
    /// </summary>
    public class EFRepositoryContext:IEFRepositoryContext
    {
        protected readonly PendingToDbObjectContainer pendingToDbObjectContainer;
        protected readonly ILogger<EFRepositoryContext> logger;

        public EFRepositoryContext(ILogger<EFRepositoryContext> logger)
        {
            this.pendingToDbObjectContainer = new PendingToDbObjectContainer();
            this.logger = logger;
        }

        public virtual void AppendAdd<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot :IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Add);
        }

        public virtual void AppendAdd(object aggregateRootEntity)
        {
            this.pendingToDbObjectContainer.Append(aggregateRootEntity, PendingToDbOperatorType.Add);
        }

        public virtual void AppendUpdate<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : IAggregateRoot
        {
            this.pendingToDbObjectContainer.Append<TAggregateRoot>(aggregateRoot, PendingToDbOperatorType.Update);
        }

        public virtual void AppendUpdate(object aggregateRootEntity)
        {
            this.pendingToDbObjectContainer.Append(aggregateRootEntity, PendingToDbOperatorType.Update);
        }

        public virtual void AppendDelete<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : IAggregateRoot
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

        public virtual bool SaveChanges()
        {
            try
            {
                foreach (Object obj in this.pendingToDbObjectContainer.GetPendingToDbList(PendingToDbOperatorType.Add))
                {
                    this.Context.Set(obj.GetType()).Add(obj);
                }
                foreach (Object obj in this.pendingToDbObjectContainer.GetPendingToDbList(PendingToDbOperatorType.Update))
                {
                    this.Context.Entry(obj).sta;
                }
                foreach (Object obj in this.pendingToDbObjectContainer.GetPendingToDbList(PendingToDbOperatorType.Delete))
                {
                    this.Context.Set(obj.GetType()).Delete(obj);
                }

                this.pendingToDbObjectContainer.Clear();
                
                return true;
            }
            catch (Exception ex)
            {
                this.logger.Error(String.Format("提交到数据库出现错误，当前Context所对应数据库连接为：{0}，详细错误信息为：",
                    this.dataContext.DataConnectString, ex.ToDetailMessage()));
                    
                return false;
            }
        }

        protected abstract void DoDispose();

        public System.Data.Entity.DbContext Context
        {
            get { throw new NotImplementedException(); }
        }
    }
}
