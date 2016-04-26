/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/25 星期一 18:03:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Data.Infrastructure;
using QuickApp.Domain.Entites;
using QuickApp.Domain.Repository;
using QuickApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuickApp.Data
{
    /// <summary>
    /// <see cref="QuickDataRepositoryContext"/>
    /// </summary>
    public class QuickDataRepositoryContext : RepositoryContext,IQuickDataRepositoryContext
    {
        private SqlDbContext context;

        public QuickDataRepositoryContext(SqlDbContext quickDataContext)
        {
            this.context = quickDataContext;
        }

        public SqlDbContext Context
        {
            get { return this.context; }
        }

        public override void Rollback()
        {
            
        }

        public override void RegisterAdded(IUnitOfWorkRepository repository, IAggregateRoot aggregateRoot)
        {
            this.context.Add(aggregateRoot);
        }

        public override void RegisterUpdated(IUnitOfWorkRepository repository, IAggregateRoot aggregateRoot)
        {
            this.context.Update(aggregateRoot);
        }

        public override void RegisterDeleted(IUnitOfWorkRepository repository, IAggregateRoot aggregateRoot)
        {
            this.context.Delete(aggregateRoot);
        }

        protected override void DoDispose(bool dispose)
        {
            if (dispose)
            {
                this.context.Dispose();
            }
        }

        protected override bool DoCommit()
        {
            try
            {
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new UnitOfWorkException(ex.ToDetailMessage());
            }
        }

    }
}
