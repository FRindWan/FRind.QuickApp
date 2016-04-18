/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/18 星期一 18:19:12
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Eventing.impl
{
    /// <summary>
    /// <see cref="EventBus"/>
    /// </summary>
    public class EventBus:IEventBus
    {
        public void Published<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public void RegisterHandler<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
