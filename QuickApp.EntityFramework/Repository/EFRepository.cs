/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/8 星期五 12:28:02
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Entites;
using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
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
    public class EFRepository<TAggregateRoot, TKey> : QuickApp.Domain.Repository.Repository<TAggregateRoot, TKey>
        where TAggregateRoot :class, IAggregateRoot
    {
        private ICurrentRepositoryContextProvider currentRepositoryContextProvider;

        public EFRepository(ICurrentRepositoryContextProvider currentRepositoryContextProvider)
            : base(currentRepositoryContextProvider)
        {
            this.currentRepositoryContextProvider = currentRepositoryContextProvider;
        }

        private IEFRepositoryContext RepositoryContext { get { return (IEFRepositoryContext)this.currentRepositoryContextProvider.Current; } }

        protected override TAggregateRoot DoGetById(TKey id)
        {
            return this.RepositoryContext.Context.Set<TAggregateRoot>().Find(id);
        }

        protected override TAggregateRoot DoGet(QuickApp.Domain.Specifications.ISpecification<TAggregateRoot> predicate)
        {
            IEnumerable<TAggregateRoot> aggregateRoots= this.DoGet(predicate,null, SortOrder.Asc);
            if (aggregateRoots == null || aggregateRoots.Count() <= 0)
            {
                return null;
            }

            return aggregateRoots.First();
        }

        protected override IEnumerable<TAggregateRoot> DoGet(QuickApp.Domain.Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, dynamic> keySelectors, SortOrder sort = SortOrder.Asc)
        {
            var query = this.RepositoryContext.Context.Set<TAggregateRoot>().Where(predicate.GetExpression());
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

    }

    public class EFRepository<TAggregateRoot> : EFRepository<TAggregateRoot, Guid> where TAggregateRoot :class, IAggregateRoot
    {
        public EFRepository(ICurrentRepositoryContextProvider currentRepositoryContextProvider)
            : base(currentRepositoryContextProvider)
        {
        }
    }
}
