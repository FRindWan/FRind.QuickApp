/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 15:01:56
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Commands;
using QuickApp.Config;
using QuickApp.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuickApp.Mvc
{
    /// <summary>
    /// <see cref="QuickAppControllerBase"/>
    /// </summary>
    public abstract class QuickAppControllerBase:Controller
    {
        private readonly ICommandExecuter commandExecuter;
        private readonly IQuery query;

        public QuickAppControllerBase()
        {
            this.commandExecuter = ConfigSource.Instance.DependencyResolver.Resolver<ICommandExecuter>();
            this.query = ConfigSource.Instance.DependencyResolver.Resolver<IQuery>();
        }

        protected ICommandExecuter CommandExecuter { get { return this.commandExecuter; } }

        public IQuery Query{ get; set; }
    }
}
