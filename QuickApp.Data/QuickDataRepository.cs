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
    public class QuickDataRepository<TAggregateRoot, TKey> : Repository<TAggregateRoot,TKey>where TAggregateRoot:IAggregateRoot
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
           
        }

        protected override TAggregateRoot DoGet(Domain.Specifications.ISpecification<TAggregateRoot> predicate)
        {
            
        }

        protected override IEnumerable<TAggregateRoot> DoGet(Domain.Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, dynamic> keySelectors, SortOrder sort = SortOrder.Asc)
        {
            throw new NotImplementedException();
        }

        protected virtual IEnumerable<TAggregateRoot> ConvertEntityForDataReader(IDataReader dataReader)
        { 
            
        }

        protected override void PersistAdded(IAggregateRoot aggregateRoot)
        {
            this.RepositoryContext.Context.ex
        }

        protected override void PersistUpdate(IAggregateRoot aggregateRoot)
        {
            base.PersistUpdate(aggregateRoot);
        }

        protected override void PersistDelete(IAggregateRoot aggregateRoot)
        {
            base.PersistDelete(aggregateRoot);
        }
    }
}
