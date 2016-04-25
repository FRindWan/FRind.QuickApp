/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/18 星期一 10:57:47
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
    /// <see cref="ReflectionExtension"/>
    /// </summary>
    public static class ReflectionExtension
    {
        public static IDictionary<Type, Type> GetAllInterfaceAndClassForAssembly(this Assembly assembly, Func<Type, bool> predicate, params Assembly[] relationAssemblys)
        {
            if (assembly == null)
            {
                return null;
            }

            IList<Type> types=GetTypes(assembly, relationAssemblys);
            if (types != null&&predicate!=null)
            {
                types = types.Where(predicate).ToList();
            }
            IList<Type> interfaceTypes = ReflectionExtension.GetInterfaceTypes(types,false);

            return GetAllInterfaceAndClassForTypes(types, interfaceTypes);
        }

        public static IDictionary<Type, Type> GetAllInterfaceAndClassForTypes(IList<Type> types, IList<Type> interfaceTypes)
        {
            if (types == null || types.Count <= 0 || interfaceTypes == null || interfaceTypes.Count <= 0)
            {
                return null;
            }

            IDictionary<Type, Type> interfaceAndClassDictionary = new Dictionary<Type, Type>();
            foreach (Type type in types)
            {
                if (!type.IsClass) 
                {
                    continue;
                }

                foreach (Type interfaceType in interfaceTypes)
                {
                    if (interfaceType.IsAssignableFrom(type))
                    {
                        interfaceAndClassDictionary.Add(interfaceType, type);
                        break;
                    }
                }
            }

            return interfaceAndClassDictionary;
        }

        public static IList<Type> GetTypes(params Assembly[] assemblys)
        {
            if (assemblys == null || assemblys.Length <= 0)
            {
                return null;
            }

            List<Type> types = new List<Type>();
            foreach (Assembly assembly in assemblys)
            {
                if (assembly == null)
                {
                    continue;
                }

                types.AddRange(assembly.GetTypes());
            }

            return types;
        }

        public static IList<Type> GetInterfaceTypes(IList<Type> types, bool inherit)
        {
            if (types == null || types.Count <= 0)
            {
                return null;
            }

            IList<Type> interfaceTypes = new List<Type>();
            foreach (Type type in types)
            {
                if (type.IsInterface)
                {
                    interfaceTypes.Add(type);
                }
            }

            if (!inherit)
            {
                // ToDo: 此处算法待调优
                for (int i = 0; i < interfaceTypes.Count; i++)
                {
                    for (int j =0; j < interfaceTypes.Count; j++)
                    {
                        if (interfaceTypes[j].GetInterface(interfaceTypes[i].Name)!=null)
                        {
                            interfaceTypes.Remove(interfaceTypes[i]);
                            break;
                        }
                    }
                }
            }

            return interfaceTypes;
        }

        public static IList<Type> FindTypesImplementInterface(Type interfaceType,params Assembly[] assemblys)
        {
            IList<Type> types = ReflectionExtension.GetTypes(assemblys);
            if (types == null||interfaceType==null)
            {
                return null;
            }

            IList<Type> findTypes = new List<Type>();
            foreach (Type type in types)
            {
                if (type.IsAbstract || type.IsInterface || type.GetInterface(interfaceType.Name)==null)
                {
                    continue;
                }

                findTypes.Add(type);
            }

            return findTypes;
        }

        public static TAttribute GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TAttribute>(MemberInfo memberInfo)
            where TAttribute : Attribute
        {
            if (memberInfo.IsDefined(typeof(TAttribute), true))
            {
                return memberInfo.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>().First();
            }

            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(typeof(TAttribute), true))
            {
                return memberInfo.DeclaringType.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>().First();
            }

            return null;
        }

        private static IList<Type> GetTypes(Assembly assembly, Assembly[] relationAssemblys)
        {
            IList<Type> types = null;
            if (relationAssemblys == null)
            {
                types = assembly.GetTypes();
            }
            else
            {
                var relationAssemblyList = relationAssemblys.ToList();
                relationAssemblyList.Add(assembly);
                types = ReflectionExtension.GetTypes(relationAssemblyList.ToArray());
            }

            return types;
        }
    }
}
