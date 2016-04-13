/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 12:06:38
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
    public interface IRepositoryContext:IUnitOfWork
    {
        void RegisterAdded<TAggregateRoot>(TAggregateRoot aggregateRoot)where TAggregateRoot :IAggregateRoot;

        void RegisterUpdated<TAggregateRoot>(TAggregateRoot aggregateRoot)where TAggregateRoot :IAggregateRoot;

        void RegisterDeleted<TAggregateRoot>(TAggregateRoot aggregateRoot)where TAggregateRoot:IAggregateRoot;
    }
}
