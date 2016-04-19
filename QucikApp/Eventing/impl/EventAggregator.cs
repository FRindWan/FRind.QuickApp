/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 10:23:37
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Eventing
{
    /// <summary>
    /// <see cref="EventAggregator"/>
    /// </summary>
    public class EventAggregator:IEventAggregator
    {
        private readonly Guid id;
        private readonly ConcurrentDictionary<Type, IList<Object>> eventHandlers ;

        public EventAggregator()
        {
            this.id = Guid.NewGuid();
            this.eventHandlers = new ConcurrentDictionary<Type, IList<Object>>();
        }

        public Guid ID
        {
            get { return this.id; }
        }

        public void Subscribe(Type eventType, object objEventHandler)
        {
            if (eventType == null || objEventHandler == null)
            {
                throw new ArgumentNullException("请提供 Event类型和 Handler");
            }

            IList<Object> eventHandlerList;
            if (this.eventHandlers.TryGetValue(eventType, out eventHandlerList))
            {
                bool isUpdate = false;
                for (int i = 0; i < eventHandlerList.Count; i++)
                {
                    if (eventHandlerList[i].GetType() == objEventHandler.GetType())
                    {
                        eventHandlerList[i] = objEventHandler;
                        isUpdate = true;
                        break;
                    }
                }
                if (!isUpdate)
                {
                    eventHandlerList.Add(objEventHandler);
                }
            }
            else
            {
                eventHandlerList = new List<Object>();
                eventHandlerList.Add(objEventHandler);
            }

            this.eventHandlers.AddOrUpdate(eventType, eventHandlerList, (t, h) => h);
        }

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler)where TEvent:IEvent 
        {
            Type eventType = eventHandler.GetType().GetInterface(typeof(IEventHandler<>).Name).GetGenericArguments()[0];
            Subscribe(eventType, eventHandler);
        }

        public void UnSubscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            Type eventType =  eventHandler.GetType().GetGenericArguments()[0];
            IList<Object> eventHandlerList;
            if (this.eventHandlers.TryGetValue(eventType, out eventHandlerList))
            {
                if (eventHandlerList.Contains(eventHandler))
                {
                    eventHandlerList.Remove(eventHandler);
                }

                if (eventHandlerList.Count <= 0)
                {
                    this.eventHandlers.TryRemove(eventType, out eventHandlerList);
                }
                else
                {
                    this.eventHandlers.AddOrUpdate(eventType, eventHandlerList, (t, h) => h);
                }
            }

        }

        public void Published<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (@event==null)
            {
                throw new ArgumentNullException("evnt 不能为空！");
            }

            Type eventType =@event.GetType();
            IList<Object> eventHandlerList;
            if (!this.eventHandlers.TryGetValue(eventType, out eventHandlerList))
            {
                return;
            }

            foreach (IEventHandler<TEvent> handler in eventHandlerList)
            {
                if (handler.GetType().IsDefined(typeof(AsyncEventHandlerAttribute), true))
                {
                    Task.Factory.StartNew(() => { handler.Handle(@event); });
                }
                else
                {
                    handler.Handle(@event);
                }
            }
            
        }

    }
}
