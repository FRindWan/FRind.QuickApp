/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/25 星期一 18:59:33
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.Repository
{
    /// <summary>
    /// <see cref="IUnitOfWorkRepository"/>
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        void PersistentAdded(IAggregateRoot aggregateRoot);

        void PersistentUpdate(IAggregateRoot aggregateRoot);

        void PersistentDelete(IAggregateRoot aggregateRoot);
    }
}
