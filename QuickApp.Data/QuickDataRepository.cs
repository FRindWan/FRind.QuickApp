/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/25 星期一 17:57:17
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Entites;
using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data
{
    /// <summary>
    /// <see cref="QuickDataRepository"/>
    /// </summary>
    public class QuickDataRepository<TAggregateRoot, TKey> : Repository<TAggregateRoot,TKey>where TAggregateRoot:class,IAggregateRoot
    {
        private ICurrentRepositoryContextProvider currentRepositoryContextProvider;
        protected readonly string dbTableName;

        public QuickDataRepository(ICurrentRepositoryContextProvider currentRepositoryContextProvider)
            : this(currentRepositoryContextProvider,typeof(TAggregateRoot).Name)
        {
           
        }

        public QuickDataRepository(ICurrentRepositoryContextProvider currentRepositoryContextProvider,string dbTableName)
            : base(currentRepositoryContextProvider)
        {
            this.currentRepositoryContextProvider = currentRepositoryContextProvider;
        }

        protected IQuickDataRepositoryContext RepositoryContext { get { return (IQuickDataRepositoryContext)this.currentRepositoryContextProvider.Current; } }

        protected override TAggregateRoot DoGetById(TKey id)
        {
            return this.RepositoryContext.Context.GetEntry(typeof(TAggregateRoot)).Find<TAggregateRoot>(id);
        }

        protected override TAggregateRoot DoGet(Domain.Specifications.ISpecification<TAggregateRoot> predicate)
        {
            IEnumerable<TAggregateRoot> aggregateRoots = this.DoGet(predicate, null);
            if (aggregateRoots == null )
            {
                return null;
            }

            return aggregateRoots.FirstOrDefault();
        }

        protected override IEnumerable<TAggregateRoot> DoGet(Domain.Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, dynamic> keySelectors, SortOrder sort = SortOrder.Asc)
        {
            return this.RepositoryContext.Context.GetEntry(typeof(TAggregateRoot)).FindAll<TAggregateRoot>(predicate.GetExpression());
        }

    }
}
