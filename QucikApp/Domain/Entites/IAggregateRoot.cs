﻿/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/24 星期四 18:35:13
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
    /// <see cref="IAggregateRoot"/>
    /// </summary>
    public interface IAggregateRoot<TKey>:IEntity<TKey>
    {

    }

    public interface IAggregateRoot : IAggregateRoot<Guid>,IEntity
    { 
    
    }
}
