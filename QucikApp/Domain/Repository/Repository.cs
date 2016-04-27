/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:22:24
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Entites;
using QuickApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.Repository
{
    /// <summary>
    /// <see cref="Repository"/>
    /// </summary>
    public abstract class Repository<TAggregateRoot, TKey,TRepostotyContext> : IRepository<TAggregateRoot, TKey>,IUnitOfWorkRepository where TAggregateRoot:IAggregateRoot
        where TRepostotyContext:IRepositoryContext
    {
        private readonly ICurrentRepositoryContextProvider currentRepositoryContextProvider;

        public Repository()
        {
            this.currentRepositoryContextProvider = Dependency.DependencyFactory.GetDependency().Resolver < ICurrentRepositoryContextProvider>();
        }

        protected TRepostotyContext RepositoryContext { get { return (TRepostotyContext)this.currentRepositoryContextProvider.Current; } }

        #region IRepository
        public TAggregateRoot GetById(TKey id)
        {
            return this.DoGetById(id);
        }

        public TAggregateRoot Get(Specifications.ISpecification<TAggregateRoot> predicate)
        {
            return this.DoGet(predicate);
        }

        public IEnumerable<TAggregateRoot> Get(Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, dynamic> keySelectors, SortOrder sort = SortOrder.Asc)
        {
            return this.DoGet(predicate, keySelectors, sort);
        }

        public bool Add(TAggregateRoot aggregateRoot)
        {
            this.currentRepositoryContextProvider.Current.RegisterAdded(this, aggregateRoot);

            return true;
        }

        public bool Update(TAggregateRoot aggregateRoot)
        {
            this.currentRepositoryContextProvider.Current.RegisterUpdated(this, aggregateRoot);

            return true;
        }

        public bool Delete(TAggregateRoot aggregateRoot)
        {
            this.currentRepositoryContextProvider.Current.RegisterDeleted(this, aggregateRoot);

            return true;
        }
        #endregion

        #region IUnitOfWorkRepository
        public void PersistentAdded(IAggregateRoot aggregateRoot) 
        {
            this.PersistAdded(aggregateRoot);
        }

        public void PersistentUpdate(IAggregateRoot aggregateRoot)
        {
            this.PersistUpdate(aggregateRoot);
        }

        public void PersistentDelete(IAggregateRoot aggregateRoot) 
        {
            this.PersistDelete(aggregateRoot);
        }

        #endregion

        protected virtual void PersistAdded(IAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        protected virtual void PersistUpdate(IAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        protected virtual void PersistDelete(IAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        protected abstract TAggregateRoot DoGetById(TKey id);

        protected abstract TAggregateRoot DoGet(Specifications.ISpecification<TAggregateRoot> predicate);

        protected abstract IEnumerable<TAggregateRoot> DoGet(Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, dynamic> keySelectors, SortOrder sort = SortOrder.Asc);


    }

    public abstract class Repository<TAggregateRoot, TRepositoryContext> : Repository<TAggregateRoot, Guid, TRepositoryContext> where TAggregateRoot : IAggregateRoot
        where TRepositoryContext:IRepositoryContext
    {
        public Repository()
        { }
    }
}
