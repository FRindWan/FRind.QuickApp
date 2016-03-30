/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:45:43
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QucikApp.Domain.Repository
{
    /// <summary>
    /// <see cref="PendingToDbObjectContainer"/>
    /// </summary>
    public class PendingToDbObjectContainer
    {
        private ThreadLocal<IList<Object>> pendingAddToDbList;
        private ThreadLocal<IList<Object>> pendingUpdateToDbList;
        private ThreadLocal<IList<Object>> pendingDeleteToDbList;

        public PendingToDbObjectContainer()
        {
            this.pendingAddToDbList = new ThreadLocal<IList<Object>>() { Value = new List<Object>() };
            this.pendingUpdateToDbList = new ThreadLocal<IList<Object>>() { Value = new List<Object>() };
            this.pendingDeleteToDbList = new ThreadLocal<IList<Object>>() { Value = new List<Object>() };
        }

        public IList<Object> GetPendingToDbList(PendingToDbOperatorType pendingToDbOperatorType)
        {
            switch (pendingToDbOperatorType)
            {
                case PendingToDbOperatorType.Add: return this.pendingAddToDbList.Value;
                case PendingToDbOperatorType.Delete: return this.pendingDeleteToDbList.Value;
                case PendingToDbOperatorType.Update: return this.pendingUpdateToDbList.Value;
                default: return null;
            }
        }

        public void Append<TAggregateRoot>(TAggregateRoot aggregateRoot,PendingToDbOperatorType type) where TAggregateRoot : IAggregateRoot
        {
            this.Append(aggregateRoot, type);
        }

        public void Append(Object aggregateRoot, PendingToDbOperatorType type) 
        {
            switch (type)
            {
                case PendingToDbOperatorType.Add: this.pendingAddToDbList.Value.Add(aggregateRoot); break;
                case PendingToDbOperatorType.Delete: this.pendingDeleteToDbList.Value.Add(aggregateRoot); break;
                case PendingToDbOperatorType.Update: this.pendingUpdateToDbList.Value.Add(aggregateRoot); break;
            }
        }

        public void Clear()
        {
            this.pendingAddToDbList.Value.Clear();
            this.pendingDeleteToDbList.Value.Clear();
            this.pendingUpdateToDbList.Value.Clear();
        }
    }
}
