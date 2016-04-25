/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/8 星期二 12:24:53
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Logger
{
    /// <summary>
    /// <see cref="LoggerInitialize"/>
    /// </summary>
    public class LoggerInitialize
    {
        public static void Load()
        {
            XmlConfigurator.Configure(new FileInfo(Path.GetDirectoryName(typeof(LoggerInitialize).Assembly.Location )+ "\\log4j.xml"));
        }
    }
}
