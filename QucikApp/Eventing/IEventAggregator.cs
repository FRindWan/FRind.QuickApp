/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 10:17:34
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Eventing
{
    /// <summary>
    /// <see cref="IEventAggregator"/>
    /// </summary>
    public interface IEventAggregator
    {
        Guid ID { get; }

        void Subscribe(Type eventType,Object objEventHandler);

        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler)where TEvent :IEvent;

        void UnSubscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

        void Published<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
