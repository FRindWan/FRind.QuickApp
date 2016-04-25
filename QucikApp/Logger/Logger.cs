using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Logger
{
    public class Logger<T>:ILogger<T>
    {
        private readonly ILog log;

        public Logger()
        {
            
            this.log = LogManager.GetLogger(typeof(T));
        }

        public void Info(object message)
        {
            if(message==null)
                throw new Exception();

            this.log.Info(message);
        }

        public void Debug(object message)
        {
            this.log.Debug(message);
        }

        public void Error(object message,Exception ex=null)
        {
            if (ex == null)
            {
                this.log.Error(message);
            }
            else
            {
                this.log.Error(message, ex);
            }
        }

        public void Warn(object message)
        {
            this.log.Warn(message);
        }
    }
}
