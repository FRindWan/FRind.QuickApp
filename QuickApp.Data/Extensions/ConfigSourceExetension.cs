/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:21:30
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Extensions
{
    /// <summary>
    /// <see cref="ConfigSourceExetension"/>
    /// </summary>
    public static class ConfigSourceExetension
    {
        public static IConfigSource UseQuickAppData(this IConfigSource configSource)
        {
            configSource.AddDependInitialize(new QuickAppDataDependInitialize());

            return configSource;
        }
    }
}
