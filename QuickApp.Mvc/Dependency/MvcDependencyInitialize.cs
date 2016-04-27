/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 11:50:29
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Reflection;
using QuickApp.Config;
using QuickApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace QuickApp.Mvc.Dependency
{
    /// <summary>
    /// <see cref="MvcDependencyInitialize"/>
    /// </summary>
    public class MvcDependencyInitialize:DependencyInitialize
    {
        public override void InitializeInterceptor(QuickApp.Dependency.Autofac.RegisterInterceptorService registerInterceptorService)
        {
            
        }

        public override void InitializeDependency(IDependencyRegister dependency)
        {
            RegisterMvcController(dependency);

            dependency.Register<IHttpControllerActivator, ApiControllerResolver>();

            ControllerBuilder.Current.SetControllerFactory(new ControllerResolver((QuickApp.Dependency.IDependencyResolver)dependency));
        }

        private static void RegisterMvcController(IDependencyRegister dependency)
        {
            IList<Type> controllerTypes = ReflectionExtension.FindTypesImplementInterface(typeof(IController), ConfigSource.Instance.WebConfigSource.MvcControllerRegisterAssemblys);
            IList<Type> apiControllerTypes = ReflectionExtension.FindTypesImplementInterface(typeof(IHttpController), ConfigSource.Instance.WebConfigSource.MvcControllerRegisterAssemblys);

            RegisterType(dependency, controllerTypes);
            RegisterType(dependency, apiControllerTypes);
        }

        private static void RegisterType(IDependencyRegister dependency, IList<Type> apiControllerTypes)
        {
            if (apiControllerTypes != null || apiControllerTypes.Count > 0)
            {
                foreach (Type type in apiControllerTypes)
                {
                    dependency.Register(type);
                }
            }
        }
    }
}
