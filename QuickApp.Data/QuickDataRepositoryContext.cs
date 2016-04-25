/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/25 星期一 18:03:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

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
        private readonly QuickDataContext context;

        public QuickDataRepositoryContext(QuickDataContext quickDataContext)
        {
            this.context = quickDataContext;
        }

        public QuickDataContext Context
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
                    addedItem.Value.PersistentAdded(addedItem.Key);
                }
                foreach (KeyValuePair<IAggregateRoot, IUnitOfWorkRepository> updateItem in this.RegisterAddedCollection)
                {
                    updateItem.Value.PersistentAdded(updateItem.Key);
                }
                foreach (KeyValuePair<IAggregateRoot, IUnitOfWorkRepository> deleteItem in this.RegisterAddedCollection)
                {
                    deleteItem.Value.PersistentAdded(deleteItem.Key);
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
