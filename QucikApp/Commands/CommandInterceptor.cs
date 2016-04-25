/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/21 星期四 10:30:20
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Commands
{
    /// <summary>
    /// <see cref="CommandInterceptor"/>
    /// </summary>
    public class CommandInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
