/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 11:17:33
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using QucikApp.Domain.Repository;
using QucikApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="UnitOfWork"/>
    /// </summary>
    public abstract class UnitOfWork:IUnitOfWork
    {
        protected IDictionary<Type,IRepositoryContextCommit> DbContexts;
        protected IDependencyResolver dependencyResolver;

        public UnitOfWork(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;

            this.DbContexts = new Dictionary<Type, IRepositoryContextCommit>();
            this.Id = Guid.NewGuid();
        }

        public event UnitOfWorkCommitComplateEventHandler OnCommitComplate;

        public event UnitOfWorkCommitErrorEventHandler OnCommitError;

        public void Commit()
        {
            try
            {
                this.OnPreCommit();

                this.OnCommit();

                this.OnComplateCommit();
                this.OnCommitComplate.Invoke(new UnitOfWorkCommitComplateEventArgs());
                this.IsCommited = true;
            }
            catch (UnitOfWorkException ex)
            {
                this.OnCommitError.Invoke(new UnitOfWorkCommitErrorEventArgs(ex));
            }
        }

        public void Rollback()
        {
            this.OnRollback();
        }

        public void Dispose()
        {
            this.IsDisposed = true;
            this.OnDispose();
        }

        public virtual TContext CreateContext<TContext>() where TContext : IRepositoryContextCommit
        {
            IRepositoryContextCommit context;
            if (!this.DbContexts.TryGetValue(typeof(TContext), out context))
            {
                context = this.dependencyResolver.Resolver<TContext>();
                this.DbContexts.Add(typeof(TContext), context);
            }

            return (TContext)context;
        }

        protected abstract void OnPreCommit();

        protected abstract void OnComplateCommit();

        protected virtual void OnCommit()
        {
            foreach (IRepositoryContextCommit context in this.DbContexts.Values)
            {
                context.SaveChanges();
            }
        }

        protected abstract void OnRollback();

        protected abstract void OnDispose();

        public bool IsCommited { get; private set; }

        public bool IsDisposed { get; private set; }

        public Guid Id { get;private set; }
    }
}
