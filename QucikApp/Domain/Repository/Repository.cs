/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:22:24
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="Repository"/>
    /// </summary>
    public class Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>where TAggregateRoot:IAggregateRoot
    {
        public Repository(IRepositoryContext context)
        {
            this.Context = context;
        }

        public IRepositoryContext Context { get; private set; }

        public TAggregateRoot GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot Get(Specifications.ISpecification<TAggregateRoot> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<TAggregateRoot> Get(Specifications.ISpecification<TAggregateRoot> predicate, SortOrder sort = SortOrder.Asc)
        {
            throw new NotImplementedException();
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
    }
}
