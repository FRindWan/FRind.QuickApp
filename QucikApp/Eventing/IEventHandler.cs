/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/18 星期一 18:14:33
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
    /// <see cref="IEventHandler"/>
    /// </summary>
    public interface IEventHandler<in TEvent>where TEvent:IEvent
    {
        void Handle(TEvent @event);
    }
}
