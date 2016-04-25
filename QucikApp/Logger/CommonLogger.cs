using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Logger
{
    public class Logger 
    {
        private readonly ILog log;

        private Logger(Type type)
        {
            this.log = LogManager.GetLogger(type);
        }

        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }

        public void Info(object message)
        {
            this.log.Info(message );
        }

        public void Debug(object message)
        {
            this.log.Debug(message );
        }

        public void Error(object message, Exception ex = null)
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
            this.log.Warn(message );
        }
    }
}
