/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 15:23:34
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Repository;
using QucikApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.EntityFramework.Repository
{
    /// <summary>
    /// <see cref="EFRepositoryContext"/>
    /// </summary>
    public class EFRepositoryContext:RepositoryContext,IEFRepositoryContext
    {
        private DbContext context;

        public EFRepositoryContext(DbContext context)
        {
            this.context = context;
        }

        public override void Rollback()
        {
        }

        protected override void DoDispose(bool dispose)
        {
            if (dispose)
            {
                if (this.IsCommited)
                {
                    this.context.Dispose();
                }
            }
        }

        protected override bool DoCommit()
        {
            try
            {
                foreach (Object aggregateRoot in this.RegisterAddedCollection.Keys)
                {
                    this.context.Set(aggregateRoot.GetType()).Add(aggregateRoot);
                }
                foreach (Object aggregateRoot in this.RegisterUpdatedCollection.Keys)
                {
                    this.context.Entry(aggregateRoot).State = EntityState.Modified;
                }
                foreach (Object aggregateRoot in this.RegisterDeleteCollection.Keys)
                {
                    this.context.Entry(aggregateRoot).State = EntityState.Deleted;
                }
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new UnitOfWorkException(ex.ToDetailMessage());
            }
        }

        public DbContext Context
        {
            get { return this.context; }
        }
    }
}
