/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 11:38:18
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuickApp.Mvc.Dependency
{
    /// <summary>
    /// <see cref="ControllerResolver"/>
    /// </summary>
    public  class ControllerResolver:DefaultControllerFactory
    {
        private readonly QuickApp.Dependency.IDependencyResolver dependency;

        public ControllerResolver(QuickApp.Dependency.IDependencyResolver dependency)
        {
            this.dependency = dependency;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new MvcException("请求数据错误，请检查，当前路由为：" + requestContext.HttpContext.Request.Url.ToString());
            }

            return (IController)this.dependency.Resolver(controllerType);
        }
    }
}
