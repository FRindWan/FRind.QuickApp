/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:21:34
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Dependency
{
    /// <summary>
    /// <see cref="IDependencyRegister"/>
    /// </summary>
    public interface IDependencyRegister
    {
        void Register(Type type, DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient);

        void Register<Type>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient);

        void Register(Type interfaceType, Type implType, DependencyLifeTime lifeTime = DependencyLifeTime.Transient);

        void Register<TInterface, TImpl>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient);

        void Register(Assembly assembly, Func<Type, bool> predicate, DependencyLifeTime lifeTime = DependencyLifeTime.Transient);

        void Register(Assembly interfaceAssembly, Assembly implAssembly, Func<Type, bool> predicate, DependencyLifeTime lifeTime = DependencyLifeTime.Transient);
    }
}
