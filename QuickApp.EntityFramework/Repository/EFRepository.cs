/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/8 星期五 12:28:02
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

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
    public class EFRepository<TAggregateRoot, TKey> : QucikApp.Domain.Repository.Repository<TAggregateRoot, TKey>
        where TAggregateRoot :class, IAggregateRoot
    {
        private IEFRepositoryContext repositoryContext;

        public EFRepository(ICurrentRepositoryContextProvider currentRepositoryContextProvider)
            : base(currentRepositoryContextProvider.Current)
        {
            this.repositoryContext = (IEFRepositoryContext)currentRepositoryContextProvider.Current;
        }

        protected IEFRepositoryContext RepositoryContext { get { return this.repositoryContext; } }

        protected override TAggregateRoot DoGetById(TKey id)
        {
            return this.repositoryContext.Context.Set<TAggregateRoot>().Find(id);
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

        protected override IEnumerable<TAggregateRoot> DoGet(QucikApp.Domain.Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, dynamic> keySelectors, SortOrder sort = SortOrder.Asc)
        {
            var query=this.repositoryContext.Context.Set<TAggregateRoot>().Where(predicate.GetExpression());
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
