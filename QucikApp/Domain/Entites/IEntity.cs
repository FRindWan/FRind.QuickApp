/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/24 星期四 18:32:32
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.Entites
{
    /// <summary>
    /// <see cref="IEntity"/>
    /// </summary>
    public interface IEntity<TKey>
    {
        TKey ID { get; set; }
    }

    /// <summary>
    /// 框架提供的默认Entity实体
    /// </summary>
    public interface IEntity : IEntity<Guid>
    { 
    
    }
}
