﻿/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/24 星期四 18:45:56
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
    /// <see cref="AggregateRoot"/>
    /// </summary>
    public abstract class AggregateRoot<TKey>:IAggregateRoot<TKey>
    {
        public TKey ID { get; set; }
    }

    public abstract class AggregateRoot : AggregateRoot<Guid>,IAggregateRoot
    { }
}
