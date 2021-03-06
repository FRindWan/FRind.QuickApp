﻿/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 10:45:08
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Config.impl
{
    /// <summary>
    /// <see cref="RepositoryConfigSource"/>
    /// </summary>
    public class RepositoryConfigSource:IRepositoryConfigSource
    {
        public Type DbContextType { get; set; }

        public Type DbContextImplType { get; set; }

        public Infrastructure.DataBaseType DbType { get; set; }
    }
}
