/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:26:20
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Dependency.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy2;
using QuickApp.Dependency.Interceptors;

namespace QuickApp.Domain.Repository
{
    /// <summary>
    /// <see cref="ApplicationInterceptorRegister"/>
    /// </summary>
    public class ApplicationInterceptorRegister : RegisterInterceptor
    {
        public override void Register<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle>(Autofac.Builder.IRegistrationBuilder<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle> registerBuilder, Type interfaceType, Type implType)
        {
            if (implType.Name.Contains("Application") )
            {
                registerBuilder.EnableInterfaceInterceptors().InterceptedBy(typeof(ApplicationInterceptor));
            }
        }
    }
}
