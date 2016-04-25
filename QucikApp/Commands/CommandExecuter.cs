/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 14:30:48
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Dependency;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Exceptions;
using System.Reflection;
using QuickApp.Common.Config;
using QuickApp.Common.Reflection;
using QuickApp.Config;
using QuickApp.Domain.UnitOfWorks;

namespace QuickApp.Commands
{
    /// <summary>
    /// <see cref="CommandExecuter"/>
    /// </summary>
    public abstract class CommandExecuter
    {
        private ConcurrentDictionary<Type, MethodInfo> handlerDictionary;

        protected CommandExecuter()
        {
            this.DependencyResolverContainer = DependencyFactory.GetDependency();
            this.handlerDictionary = this.LoadHandlerDictionary(ConfigSource.Instance.CommandConfigSource);
        }

        private IDependencyResolver DependencyResolverContainer { get; set; }
        
        public virtual Object Execute(ICommand command)
        {
            if (command == null)
            {
                throw new CommandException("请传入有效的命令！");
            }

            MethodInfo handlerMethod = this.GetHandlerMethod(command.GetType());
            Object handler = this.GetHandlerObj(handlerMethod.ReflectedType);

            return this.ExecuterCommand(handlerMethod, handler, command);
        }

        public virtual async Task<Object> ExecuteAsync(ICommand command)
        {
            return await Task.Run<Object>(() => { return this.Execute(command); });
        }

        protected MethodInfo GetHandlerMethod(Type commandType)
        {
            MethodInfo handlerMethod;
            if (!this.handlerDictionary.TryGetValue(commandType, out handlerMethod))
            {
                throw new CommandException(String.Format("未能找到该类型为{0}的命令处理器，请检查是否为该命令标注处理器！", commandType.Name));
            }

            return handlerMethod;
        }

        protected Object GetHandlerObj(Type handlerType)
        {
            if (handlerType == null)
            {
                throw new ArgumentNullException("未将对象引入到对象中！");
            }

            Object handler = this.DependencyResolverContainer.Resolver(handlerType);
            if (handler == null)
            {
                throw new CommandException(String.Format("未能从系统中获取到类型为{0}的处理器实例，请检查该实例是否注册到系统中！"));
            }

            return handler;
        }

        protected virtual ConcurrentDictionary<Type, MethodInfo> LoadHandlerDictionary(ICommandConfigSource config)
        {
            ConcurrentDictionary<Type, MethodInfo> dictionary = new ConcurrentDictionary<Type, MethodInfo>();

            IList<MethodInfo> methodInfos = MethodInfoHelper.FindMethodForAttribute(typeof(CommandExecuteAttribute), config.Assemblys);
            if (methodInfos == null || methodInfos.Count <= 0)
            {
                return dictionary;
            }

            foreach (MethodInfo methodInfo in methodInfos)
            {
                Type commandType=methodInfo.GetCustomAttribute<CommandExecuteAttribute>().CommandType;
                if (dictionary.ContainsKey(commandType))
                {
                    MethodInfo currentMethod=dictionary[commandType];
                    throw new CommandException(String.Format("当前命令{0}已注册处理器{1}->{2}，无法继续将该命令注册到新处理器{3}->{4}，请检查！", commandType, currentMethod.ReflectedType,currentMethod, methodInfo.ReflectedType,methodInfo));
                }

                dictionary.GetOrAdd(commandType, methodInfo);
            }

            return dictionary;
        }

        protected Object ExecuterCommand(MethodInfo handlerMethod, Object handler, ICommand command)
        {
            ICurrentRepositoryContextProvider repositoryContextProvider = this.DependencyResolverContainer.Resolver<ICurrentRepositoryContextProvider>();
            IRepositoryContextManager repositoryContextManager = this.DependencyResolverContainer.Resolver<IRepositoryContextManager>();
            try
            {

                if (repositoryContextProvider.Current == null)
                {
                    repositoryContextManager.Create();
                }

                Object obj=handlerMethod.Invoke(handler, new Object[] { command });

                if (!repositoryContextProvider.Current.IsCommited)
                {
                    repositoryContextProvider.Current.Commit();
                }

                return obj;
            }
            catch (ArgumentException ex)
            {
                throw new CommandException(String.Format("命令处理器{0}的类型参数不对，请更改为{1}类型", handlerMethod.ToString(), command.GetType()));
            }
        }
    }
}
