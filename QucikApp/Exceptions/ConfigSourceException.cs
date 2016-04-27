/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 10:51:12
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Exceptions
{
    /// <summary>
    /// <see cref="ConfigSourceException"/>
    /// </summary>
    public class ConfigSourceException:QuickAppException
    {
        public ConfigSourceException(String message)
            : base(message)
        { 
        
        }
    }
}
