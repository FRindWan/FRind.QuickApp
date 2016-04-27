/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 10:43:27
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Config
{
    /// <summary>
    /// <see cref="IRepositoryConfigSource"/>
    /// </summary>
    public interface IRepositoryConfigSource
    {
        Type DbContextType { get; set; }

        Type DbContextImplType { get; set; }

        DataBaseType DbType { get; set; }
    }
}
