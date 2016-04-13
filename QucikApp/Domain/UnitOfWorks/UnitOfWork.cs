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
        public UnitOfWork()
        {
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
        
        protected abstract void OnPreCommit();

        protected abstract void OnComplateCommit();

        protected abstract void OnCommit();

        protected abstract void OnRollback();

        protected abstract void OnDispose();

        public bool IsCommited { get; private set; }

        public bool IsDisposed { get; private set; }

        public Guid Id { get;private set; }
    }
}
