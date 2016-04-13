/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:22:24
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="Repository"/>
    /// </summary>
    public abstract class Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>where TAggregateRoot:IAggregateRoot
    {
        public Repository()
        {
        }

        public TAggregateRoot GetById(TKey id)
        {
            return this.DoGetById(id);
        }

        public TAggregateRoot Get(Specifications.ISpecification<TAggregateRoot> predicate)
        {
            return this.DoGet(predicate);
        }

        public IEnumerable<TAggregateRoot> Get(Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, TKey> keySelectors, SortOrder sort = SortOrder.Asc)
        {
            return this.DoGet(predicate, sort);
        }

        public bool Add(TAggregateRoot aggregateRoot)
        {
            this.Context.AppendAdd<TAggregateRoot>(aggregateRoot);

            return true;
        }

        public bool Update(TAggregateRoot aggregateRoot)
        {
            this.Context.AppendUpdate<TAggregateRoot>(aggregateRoot);

            return true;
        }

        public bool Delete(TAggregateRoot aggregateRoot)
        {
            this.Context.AppendDelete(aggregateRoot);

            return true;
        }

        protected abstract TAggregateRoot DoGetById(TKey id);

        protected abstract TAggregateRoot DoGet(Specifications.ISpecification<TAggregateRoot> predicate);

        protected abstract IEnumerable<TAggregateRoot> DoGet(Specifications.ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, TKey> keySelectors, SortOrder sort = SortOrder.Asc);

        protected abstract bool DoAdd(TAggregateRoot aggregateRoot);

        protected abstract bool DoUpdate(TAggregateRoot aggregateRoot);

        protected abstract bool DoDelete(TAggregateRoot aggregateRoot);
    }
}
