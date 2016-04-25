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
                TransactionScope transactionScope = new TransactionScope();

                foreach (KeyValuePair<IAggregateRoot,IUnitOfWorkRepository> addedItem in this.RegisterAddedCollection)
                {
                    this.context.Add<IAggregateRoot>(addedItem.Key);
                }
                foreach (KeyValuePair<IAggregateRoot, IUnitOfWorkRepository> updateItem in this.RegisterAddedCollection)
                {
                    this.context.Update<IAggregateRoot>(updateItem.Key);
                }
                foreach (KeyValuePair<IAggregateRoot, IUnitOfWorkRepository> deleteItem in this.RegisterAddedCollection)
                {
                    this.context.Delete<IAggregateRoot>(deleteItem.Key);
                }
                transactionScope.Complete();

                return true;
            }
            catch (Exception ex)
            {
                throw new UnitOfWorkException(ex.ToDetailMessage());
            }
        }

    }
}
