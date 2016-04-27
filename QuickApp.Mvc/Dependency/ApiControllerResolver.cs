/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 11:42:05
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Net.Http;

namespace QuickApp.Mvc.Dependency
{
    /// <summary>
    /// <see cref="ApiControllerResolver"/>
    /// </summary>
    public class ApiControllerResolver : IHttpControllerActivator
    {
        private readonly QuickApp.Dependency.IDependencyResolver dependency;

        public ApiControllerResolver(QuickApp.Dependency.IDependencyResolver dependency)
        {
            this.dependency = dependency;
        }

        public IHttpController Create(System.Net.Http.HttpRequestMessage request, System.Web.Http.Controllers.HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)this.dependency.Resolver(controllerType);

            //request.RegisterForDispose(new DisposeAction(() => { this.iocManager.Release(controller); }));

            return controller;
        }

       
    }
}
