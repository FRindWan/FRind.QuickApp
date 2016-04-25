﻿/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/21 星期四 10:15:27
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

namespace QuickApp.Commands
{
    /// <summary>
    /// <see cref="CommandInterceptorRegister"/>
    /// </summary>
    public class CommandInterceptorRegister : RegisterInterceptor
    {
        public override void Register<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle>(Autofac.Builder.IRegistrationBuilder<TLimit, TConcreteReflectionActivatorData, TRegistrationStyle> registerBuilder, Type interfaceType, Type implType)
        {
            if(implType.GetMethods().FirstOrDefault(p=>p.IsDefined(typeof(CommandExecuteAttribute),true))!=null)
            {
                registerBuilder.EnableClassInterceptors().InterceptedBy(typeof(CommandInterceptor));
            }
        }
    }
}
