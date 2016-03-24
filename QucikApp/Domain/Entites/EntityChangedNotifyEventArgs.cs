/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/24 星期四 18:49:09
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.Entites
{
    /// <summary>
    /// <see cref="EntityChangedNotifyEvent"/>
    /// </summary>
    public delegate void EntityChangedNotify(object sender,EntityChangedNotifyEventArgs e);

    public class EntityChangedNotifyEventArgs
    {
        public String Name{get;set;}

        public Object OldValue{get;set;}

        public Object NewValue{get;set;}
    }
}
