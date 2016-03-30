/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:31:24
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Dependency
{
    /// <summary>
    /// <see cref="Dependency"/>
    /// </summary>
    public abstract class Dependency:IDependency
    {

        public void Register(Type type, DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            throw new NotImplementedException();
        }

        public void Register<Type>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            throw new NotImplementedException();
        }

        public void Register(Type interfaceType, Type implType, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            throw new NotImplementedException();
        }

        public void Register<TInterface, TImpl>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            throw new NotImplementedException();
        }

        public void Register(System.Reflection.Assembly assembly, Func<Type, bool> predicate, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            throw new NotImplementedException();
        }

        public object Resolver(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolver<T>()
        {
            throw new NotImplementedException();
        }

        public bool IsRegisted(Type type)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
