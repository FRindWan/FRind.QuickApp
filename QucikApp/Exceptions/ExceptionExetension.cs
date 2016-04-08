/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/8 星期五 12:04:13
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Exceptions
{
    /// <summary>
    /// <see cref="ExceptionExetension"/>
    /// </summary>
    public static class ExceptionExetension
    {
        public static String ToDetailMessage(this Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            return GetInnerExceptionMessage(ex, new StringBuilder());
        }

        private static String GetInnerExceptionMessage(Exception ex, StringBuilder message)
        {
            if (ex == null)
            {
                return message.ToString();
            }

            message.AppendFormat("  内部错误信息：{0}\r\n下一级错误：", ex.Message);
            if (ex.InnerException == null)
            {
                return message.ToString();
            }

            return GetInnerExceptionMessage(ex.InnerException, message);
            
        }
    }
}
