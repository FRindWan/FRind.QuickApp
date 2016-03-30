/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:07:07
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Entites;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="IRepositoryContext"/>
    /// </summary>
    public interface IRepositoryContext:IDisposable
    {
        void AppendAdd<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot :IAggregateRoot;

        void AppendAdd(Object aggregateRootEntity);

        void AppendUpdate<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : IAggregateRoot;

        void AppendUpdate(Object aggregateRootEntity);

        void AppendDelete<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : IAggregateRoot;

        void AppendDelete(Object aggregateRoot);

        
    }
}
