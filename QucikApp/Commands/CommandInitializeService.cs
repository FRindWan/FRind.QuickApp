/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 15:44:54
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Reflection;
using QuickApp.Config;
using QuickApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Commands
{
    /// <summary>
    /// <see cref="CommandInitializeService"/>
    /// </summary>
    public static class CommandInitializeService
    {
        static CommandInitializeService()
        {
        }

        private static IDependencyRegister RegisterContainer { get { return DependencyFactory.GetDependency(); } }

        public static void Initialize()
        {
            CommandInitializeService.RegisterCommandExecuter<QuickAppCommandExecuter>();
            CommandInitializeService.RegisterCommandHandler();
        }

        public static void RegisterCommandExecuter<TCommandExecuter>()where TCommandExecuter:CommandExecuter
        {
            CommandInitializeService.RegisterContainer.Register<ICommandExecuter,TCommandExecuter>(DependencyLifeTime.Singleton);
        }

        private static void RegisterCommandHandler()
        {
            IList<MethodInfo> methodInfos = MethodInfoHelper.FindMethodForAttribute(typeof(CommandExecuteAttribute), ConfigSource.Instance.CommandConfigSource.Assemblys);
            if (methodInfos == null || methodInfos.Count <= 0)
            {
                return;
            }

            foreach (MethodInfo methodInfo in methodInfos)
            {
                CommandInitializeService.RegisterContainer.Register(methodInfo.ReflectedType);
            }
        }
    }
}
