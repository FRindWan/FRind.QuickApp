/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 12:09:39
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QucikApp.Exceptions;
using QucikApp.Logger;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="RepositoryContext"/>
    /// </summary>
    public abstract class RepositoryContext:IRepositoryContext
    {
        private readonly ConcurrentDictionary<Object, byte> registerAddedCollection = new ConcurrentDictionary<object, byte>();
        private readonly ConcurrentDictionary<Object, byte> registerUpdatedCollection = new ConcurrentDictionary<object, byte>();
        private readonly ConcurrentDictionary<Object, byte> registerDeleteCollection = new ConcurrentDictionary<object, byte>();
        private volatile bool isCommited;
        private readonly Guid id;
        protected bool isDisposed;

        public RepositoryContext()
        {
            this.isCommited = false;
            this.id = Guid.NewGuid();
            this.isDisposed = false;
        }

        protected ConcurrentDictionary<Object, byte> RegisterAddedCollection { get { return this.registerAddedCollection; } }

        protected ConcurrentDictionary<Object, byte> RegisterUpdatedCollection { get { return this.registerUpdatedCollection; } }

        protected ConcurrentDictionary<Object, byte> RegisterDeleteCollection { get { return this.registerDeleteCollection; } }

        public void RegisterAdded<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.RegisterAddedCollection.AddOrUpdate(aggregateRoot, byte.MinValue, (o, b) => byte.MinValue);
        }

        public void RegisterUpdated<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.RegisterUpdatedCollection.AddOrUpdate(aggregateRoot, byte.MinValue, (o, b) => byte.MinValue);
        }

        public void RegisterDeleted<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : Entites.IAggregateRoot
        {
            this.RegisterDeleteCollection.AddOrUpdate(aggregateRoot, byte.MinValue, (o, b) => byte.MinValue);
        }

        public event UnitOfWorks.UnitOfWorkCommitComplateEventHandler OnCommitComplate;

        public event UnitOfWorks.UnitOfWorkCommitErrorEventHandler OnCommitError;

        public Guid Id
        {
            get { return this.id; }
        }

        public bool IsCommited
        {
            get { return this.isCommited; }
        }

        public bool IsDisposed
        {
            get { return this.isDisposed; }
        }

        public void Commit()
        {
            try
            {
                this.DoCommit();
                this.isCommited = true;
                if (this.OnCommitComplate != null)
                {
                    this.OnCommitComplate.Invoke(new UnitOfWorks.UnitOfWorkCommitComplateEventArgs());
                }
            }
            catch (UnitOfWorkException unitOfWorkException)
            {
                LoggerFactory.GetLogger<RepositoryContext>().Error("提交出现错误！", unitOfWorkException);
                if (this.OnCommitError != null)
                {
                    this.OnCommitError.Invoke(new UnitOfWorks.UnitOfWorkCommitErrorEventArgs(unitOfWorkException));
                }
            }
        }

        public abstract void Rollback();

        public void Dispose()
        {
            this.ClearRegistation();
        }

        protected abstract void DoDispose(bool dispose);

        protected abstract bool DoCommit();

        protected void ClearRegistation()
        {
            this.RegisterAddedCollection.Clear();
            this.RegisterUpdatedCollection.Clear();
            this.RegisterDeleteCollection.Clear();
        }
    }
}
