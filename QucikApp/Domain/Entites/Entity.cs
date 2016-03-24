/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/24 星期四 18:46:40
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
    /// <see cref="Entity"/>
    /// </summary>
    public abstract class Entity<TKey>:IEntity<TKey>
    {
        public event EntityChangedNotify PropertyChangedNotifyEvent;

        public Entity()
        {
            
        }

        public TKey ID { get; set; }



    }
}
