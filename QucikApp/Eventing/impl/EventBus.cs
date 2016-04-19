/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/18 星期一 18:19:12
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace QuickApp.Eventing.impl
{
    /// <summary>
    /// <see cref="EventBus"/>
    /// </summary>
    public class EventBus:IEventBus
    {
        private readonly IEventAggregator eventAggregator;
        private Guid id;
        private bool isCommited;
        private bool isDisposed;
        private ConcurrentQueue<Object> queues;
        private readonly MethodInfo publishMethod;

        public EventBus(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.id = Guid.NewGuid();
            this.isCommited = false;
            this.isDisposed = false;
            this.queues = new ConcurrentQueue<object>();

            publishMethod = (from m in this.eventAggregator.GetType().GetMethods()
                             let parameters = m.GetParameters()
                             let methodName = m.Name
                             where methodName == "Published" &&
                             parameters != null &&
                             parameters.Length == 1
                             select m).First();
        }

        public void Published<TEvent>(TEvent @event) where TEvent : IEvent
        {
            this.queues.Enqueue(@event);
        }

        public event Domain.UnitOfWorks.UnitOfWorkCommitComplateEventHandler OnCommitComplate;

        public event Domain.UnitOfWorks.UnitOfWorkCommitErrorEventHandler OnCommitError;

        public Guid Id
        {
            get { return this.id; }
        }

        public bool IsCommited
        {
            get { return this.isCommited; }
        }

        public bool IsDisposed
        {
            get { return this.isDisposed; }
        }

        public void Commit()
        {
            while (this.queues.Count > 0)
            { 
                Object objEvent;
                if (!this.queues.TryDequeue(out objEvent))
                {
                    continue;
                }

                publishMethod.Invoke(this.eventAggregator, new Object[] { objEvent });
            }
        }

        public void Rollback()
        {
            
        }

        public void Dispose()
        {
            this.Clear();
            this.isDisposed = true;
        }


        public void Clear()
        {
            this.queues = new ConcurrentQueue<object>();
        }
    }
}
