/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 10:18:49
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
    /// <see cref="UnitOfWorkException"/>
    /// </summary>
    public class UnitOfWorkException : QuickAppException
    {
        public UnitOfWorkException(String errorMessage)
            : base(errorMessage)
        { 
        }
    }
}
