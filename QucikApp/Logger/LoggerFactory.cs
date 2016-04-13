/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 15:11:43
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Logger
{
    /// <summary>
    /// <see cref="LoggerFactory"/>
    /// </summary>
    public class LoggerFactory
    {
        public static ILogger<T> GetLogger<T>() where T:class
        {
            return new DefaultLogger<T>();
        }

        public static ILogger<LoggerFactory> GetLogger()
        {
            return new DefaultLogger<LoggerFactory>();
        }
    }
}
