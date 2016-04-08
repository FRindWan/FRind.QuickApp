/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/8 星期五 12:28:02
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Data;
using QucikApp.Domain.Entites;
using QucikApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.EntityFramework.Repository
{
    /// <summary>
    /// <see cref="EFRepository"/>
    /// </summary>
    public class EFRepository<TAggregateRoot, TKey> : QucikApp.Domain.Repository.Repository<TAggregateRoot, TKey>
        where TAggregateRoot:IAggregateRoot
    {
        public EFRepository(IRepositoryContext repositoryContext)
            : base(repositoryContext)
        { 
        
        }

        protected override TAggregateRoot DoGetById(TKey id)
        {
            base.Context.
        }

        protected override TAggregateRoot DoGet(QucikApp.Domain.Specifications.ISpecification<TAggregateRoot> predicate)
        {
            throw new NotImplementedException();
        }

        protected override IList<TAggregateRoot> DoGet(QucikApp.Domain.Specifications.ISpecification<TAggregateRoot> predicate, QucikApp.Domain.Repository.SortOrder sort = SortOrder.Asc)
        {
            throw new NotImplementedException();
        }
    }
}
