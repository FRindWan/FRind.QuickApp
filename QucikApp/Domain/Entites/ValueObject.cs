/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/22 星期五 15:32:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Domain.Entites
{
    /// <summary>
    /// <see cref="ValueObject"/>
    /// </summary>
    public abstract class ValueObject<T>where T:ValueObject<T>
    {
        public static bool operator ==(ValueObject<T> left,ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

    }
}
