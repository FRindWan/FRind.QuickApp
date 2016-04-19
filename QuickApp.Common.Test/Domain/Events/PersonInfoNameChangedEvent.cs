/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 14:51:28
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Test.Domain.Model;
using QuickApp.Eventing;
using QuickApp.Eventing.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Domain.Events
{
    /// <summary>
    /// <see cref="PersonInfoNameChangedEvent"/>
    /// </summary>
    public class PersonInfoNameChangedEvent:Event
    {
        public PersonInfo PersonInfo { get; set; }
    }
}
