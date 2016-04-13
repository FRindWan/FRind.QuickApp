/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 9:54:04
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Entites;
using QucikApp.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="IRepository"/>
    /// </summary>
    public interface IRepository<TAggregateRoot,TKey> where TAggregateRoot:IAggregateRoot
    {
        TAggregateRoot GetById(TKey id);

        TAggregateRoot Get(ISpecification<TAggregateRoot> predicate);

        IEnumerable<TAggregateRoot> Get(ISpecification<TAggregateRoot> predicate, Func<TAggregateRoot, dynamic> keySelectors, SortOrder sort = SortOrder.Asc);

        bool Add(TAggregateRoot aggregateRoot);

        bool Update(TAggregateRoot aggregateRoot);

        bool Delete(TAggregateRoot aggregateRoot);
    }

    public interface IRepository<TAggregateRoot> : IRepository<TAggregateRoot, Guid> where TAggregateRoot : IAggregateRoot
    { 
    
    }
}
