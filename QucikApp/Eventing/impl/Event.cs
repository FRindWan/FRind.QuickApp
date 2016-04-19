/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 14:52:26
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
    /// <see cref="Event"/>
    /// </summary>
    public class Event:IEvent
    {
        public Event()
        {
            this.ID = Guid.NewGuid();
            this.CreateTime = DateTime.Now;
        }

        public Guid ID { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
