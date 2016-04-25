/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:02:28
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Dependency.Autofac
{
    /// <summary>
    /// <see cref="RegisterInterceptor"/>
    /// </summary>
    public abstract class RegisterInterceptor
    {
        public abstract void Register<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle>(IRegistrationBuilder<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle> registerBuilder, Type interfaceType, Type implType);
    }
}
