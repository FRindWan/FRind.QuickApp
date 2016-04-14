/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 10:39:14
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Application
{
    /// <summary>
    /// <see cref="IPersonInfoApplication"/>
    /// </summary>
    public interface IPersonInfoApplication
    {
        void AddPersonInfo(String name, int age);
    }
}
