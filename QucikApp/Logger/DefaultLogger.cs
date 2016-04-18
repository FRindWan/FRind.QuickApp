/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/7 星期四 17:33:41
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Logger
{
    /// <summary>
    /// <see cref="DefaultLogger"/>
    /// </summary>
    public class DefaultLogger<T>:ILogger<T>
    {
        private ILog logger;

        public DefaultLogger()
        {
            this.logger = LogManager.GetLogger(typeof(T));
        }

        public void Info(object message)
        {
            this.logger.Info(message);
        }

        public void Debug(object message)
        {
            this.logger.Debug(message);
        }

        public void Wran(object message)
        {
            this.logger.Warn(message);
        }

        public void Error(object message)
        {
            this.logger.Error(message);
        }

        public void Error(object message, Exception ex)
        {
            this.logger.Error(message, ex);
        }
    }
}
