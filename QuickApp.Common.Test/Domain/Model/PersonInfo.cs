/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:28:04
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Test.Domain.Events;
using QuickApp.Domain.Entites;
using QuickApp.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Domain.Model
{
    /// <summary>
    /// <see cref="PersonInfo"/>
    /// </summary>
    public class PersonInfo : IAggregateRoot
    {
        public Guid ID { get; set; }

        public String UserName { get; set; }

        public int Age { get; set; }
    }
}
