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
using QuickApp.Exceptions;
using QuickApp.Logger;
using QuickApp.Domain.Entites;

namespace QuickApp.Domain.Repository
{
    /// <summary>
    /// <see cref="RepositoryContext"/>
    /// </summary>
    public abstract class RepositoryContext:IRepositoryContext
    {
        private readonly ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository> registerAddedCollection = new ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository>();
        private readonly ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository> registerUpdatedCollection = new ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository>();
        private readonly ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository> registerDeleteCollection = new ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository>();
        private volatile bool isCommited;
        private readonly Guid id;
        protected bool isDisposed;

        public RepositoryContext()
        {
            this.isCommited = false;
            this.id = Guid.NewGuid();
            this.isDisposed = false;
        }

        protected ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository> RegisterAddedCollection { get { return this.registerAddedCollection; } }

        protected ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository> RegisterUpdatedCollection { get { return this.registerUpdatedCollection; } }

        protected ConcurrentDictionary<IAggregateRoot, IUnitOfWorkRepository> RegisterDeleteCollection { get { return this.registerDeleteCollection; } }
        

        public event UnitOfWorks.UnitOfWorkCommitComplateEventHandler OnCommitComplate;

        public event UnitOfWorks.UnitOfWorkCommitErrorEventHandler OnCommitError;

        #region RepositoryContext Implements Method
        public virtual void RegisterAdded(IUnitOfWorkRepository repository, IAggregateRoot aggregateRoot)
        {
            this.registerAddedCollection.AddOrUpdate(aggregateRoot, repository, (k, v) => v);
        }

        public virtual void RegisterUpdated(IUnitOfWorkRepository repository, IAggregateRoot aggregateRoot) 
        {
            this.registerUpdatedCollection.AddOrUpdate(aggregateRoot, repository, (k, v) => v);
        }

        public virtual void RegisterDeleted(IUnitOfWorkRepository repository, IAggregateRoot aggregateRoot)
        {
            this.registerDeleteCollection.AddOrUpdate(aggregateRoot, repository, (k, v) => v);
        }

        #endregion

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
                Logger.Logger.GetLogger(typeof(RepositoryContext)).Error("提交出现错误！", unitOfWorkException);
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
            this.DoDispose(true);
            this.isDisposed = true;
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
