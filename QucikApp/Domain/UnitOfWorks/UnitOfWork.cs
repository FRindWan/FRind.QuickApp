/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 11:17:33
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using QucikApp.Domain.Repository;
using QucikApp.Exceptions;
using QucikApp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="UnitOfWork"/>
    /// </summary>
    public abstract class UnitOfWork:IUnitOfWork
    {
        protected IDictionary<Type,IRepositoryContextCommit> DbContexts;
        protected IDependencyResolver dependencyResolver;
        protected ILogger<UnitOfWork> logger;

        public UnitOfWork(IDependencyResolver dependencyResolver, ILogger<UnitOfWork> logger)
        {
            this.dependencyResolver = dependencyResolver;
            this.logger = logger;

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
            TransactionScope transaction = new TransactionScope();
            bool commitStatus = true;
            foreach (IRepositoryContextCommit context in this.DbContexts.Values)
            {
                if (!context.SaveChanges())
                {
                    commitStatus = false;
                    break;
                }
            }

            if (!commitStatus)
            {
                transaction.Dispose();
                this.logger.Error("在提交的时候出现错误，本次提交失败！");
                throw new UnitOfWorkException("提交到数据库过程中，出现提交失败，有关细节请查阅日志文件！");
            }

            transaction.Complete();
        }

        protected abstract void OnRollback();

        protected abstract void OnDispose();

        public bool IsCommited { get; private set; }

        public bool IsDisposed { get; private set; }

        public Guid Id { get;private set; }
    }
}
