/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/8 星期五 12:28:02
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Data;
using QucikApp.Domain.Entites;
using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.EntityFramework.Repository
{
    /// <summary>
    /// <see cref="EFRepository"/>
    /// </summary>
    public class EFRepository<TAggregateRoot, TKey,TContext> : QucikApp.Domain.Repository.Repository<TAggregateRoot, TKey>
        where TAggregateRoot : class,IAggregateRoot
        where TContext:DbContext
    {
        private IUnitOfWorkContextProvider<TContext> contextProvider;
        private TContext context;

        public EFRepository(IUnitOfWorkContextProvider<TContext> contextProvider)
        {
            this.contextProvider = contextProvider;
            this.context = contextProvider.Context;
        }

        protected override TAggregateRoot DoGetById(TKey id)
        {
            return this.context.Set<TAggregateRoot>().Find(id);
        }

        protected override TAggregateRoot DoGet(QucikApp.Domain.Specifications.ISpecification<TAggregateRoot> predicate)
        {
            IEnumerable<TAggregateRoot> aggregateRoots= this.DoGet(predicate,null, SortOrder.Asc);
            if (aggregateRoots == null || aggregateRoots.Count() <= 0)
            {
                return null;
            }

            return aggregateRoots.First();
        }

        protected override IEnumerable<TAggregateRoot> DoGet(QucikApp.Domain.Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, TKey> keySelectors, SortOrder sort = SortOrder.Asc)
        {
            var query=this.context.Set<TAggregateRoot>().Where(predicate.GetExpression());
            if (keySelectors == null)
            {
                return query;
            }

            if (sort == SortOrder.Asc)
            {
                return query.OrderBy(keySelectors).AsEnumerable();
            }
            else if(sort== SortOrder.Desc)
            {
                return query.OrderByDescending(keySelectors).AsEnumerable();
            }

            return query;
        }

        protected override bool DoAdd(TAggregateRoot aggregateRoot)
        {
            this.context.Set<TAggregateRoot>().Add(aggregateRoot);

            return true;
        }

        protected override bool DoUpdate(TAggregateRoot aggregateRoot)
        {
            this.context.Entry<TAggregateRoot>(aggregateRoot).State = EntityState.Modified;

            return true;
        }

        protected override bool DoDelete(TAggregateRoot aggregateRoot)
        {
            this.context.Entry<TAggregateRoot>(aggregateRoot).State = EntityState.Deleted;

            return true;
        }
    }
}
