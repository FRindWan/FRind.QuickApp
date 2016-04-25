using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Logger
{
    public interface ILogger<T>
    {
        void Info(object message);

        void Debug(object message);

        void Error(object message,Exception ex=null);

        void Warn(object message);
    }

}
