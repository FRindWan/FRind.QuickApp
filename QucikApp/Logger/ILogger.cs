/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/7 星期四 17:31:39
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Logger
{
    /// <summary>
    /// <see cref="ILogger"/>
    /// </summary>
    public interface ILogger<T>
    {
        void Info(Object message);

        void Debug(Object message);

        void Wran(Object message);

        void Error(Object message);

        void Error(Object message, Exception ex);
    }
}
