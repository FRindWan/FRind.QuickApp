/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:25:41
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data
{
    /// <summary>
    /// <see cref="DefaultSqlDbContext"/>
    /// </summary>
    public class DefaultSqlDbContext:SqlDbContext
    {
        public DefaultSqlDbContext()
            : base("default")
        { }
    }
}
