/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/18 星期一 15:21:50
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
    /// <see cref="IEventBus"/>
    /// </summary>
    public interface IEventBus
    {
        void Published<TEvent>(TEvent @event)where TEvent:IEvent;

        void RegisterHandler<TEvent>(IEventHandler<TEvent> handler)where TEvent:IEvent;
    }
}
