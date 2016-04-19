/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 10:54:17
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Reflection;
using QuickApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Eventing
{
    /// <summary>
    /// <see cref="EventInitialize"/>
    /// </summary>
    public class EventInitialize
    {
        private static IDependency dependency;

        static EventInitialize()
        {
            EventInitialize.dependency = DependencyFactory.GetDependency();
        }

        public static void Initialize(params Assembly[] assemblys)
        {
            IList<Type> handlerTypes = ReflectionExtension.FindTypesImplementInterface(typeof(IEventHandler<>), assemblys);
            if (handlerTypes == null || handlerTypes.Count <= 0)
            {
                return;
            }

            foreach (Type handlerType in handlerTypes)
            {
                EventInitialize.dependency.Register(handlerType);
            }

            foreach (Type handlerType in handlerTypes)
            {
                EventInitialize.dependency.Resolver<IEventAggregator>().Subscribe(handlerType.GetInterface(typeof(IEventHandler<>).Name).GetGenericArguments()[0],EventInitialize.dependency.Resolver(handlerType));
            }
        }

    }
}
