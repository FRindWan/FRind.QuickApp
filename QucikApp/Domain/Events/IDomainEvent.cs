/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 10:52:48
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.Events
{
    /// <summary>
    /// <see cref="IDomainEvent"/>
    /// </summary>
    public interface IDomainEvent:IEvent
    {
    }
}
