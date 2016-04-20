/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 14:51:37
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Reflection
{
    /// <summary>
    /// <see cref="MethodInfoHelper"/>
    /// </summary>
    public static class MethodInfoHelper
    {
        public static IList<MethodInfo> FindMethodForAttribute(Type type, Type attributeType)
        {
            if (type == null || attributeType == null)
            {
                throw new ArgumentNullException("要获取带有指定标签的方法，请传入有效的类类型和标签类类型！");
            }

            IList<MethodInfo> methodInfos = new List<MethodInfo>();
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                if (methodInfo.IsDefined(attributeType, true))
                {
                    methodInfos.Add(methodInfo);
                }
            }

            return methodInfos;
        }

        public static IList<MethodInfo> FindMethodForAttribute(Type attributeType, params Assembly[] assemblys)
        {
            IList<Type> types = ReflectionExtension.GetTypes(assemblys);
            if (types == null)
            {
                return null;
            }

            List<MethodInfo> methodInfos = new List<MethodInfo>();
            foreach (Type type in types)
            {
                IList<MethodInfo> methodInfoItems = MethodInfoHelper.FindMethodForAttribute(type, attributeType);
                if (methodInfoItems == null || methodInfoItems.Count <= 0)
                {
                    continue;
                }

                methodInfos.AddRange(methodInfoItems);
            }

            return methodInfos;
        }
    }
}
