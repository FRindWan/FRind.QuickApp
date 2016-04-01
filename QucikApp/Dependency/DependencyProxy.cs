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
    /// <see cref="DependencyProxy"/>
    /// </summary>
    public class DependencyProxy:IDependency
    {
        private IDependency dependency;

        public DependencyProxy()
        {
            this.dependency = DependencyFactory.GetDependency();
        }


        public void Register(Type type, DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            this.dependency.Register(type, dependencyLifeTime);
        }

        public void Register<Type>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            this.dependency.Register<Type>(dependencyLifeTime);
        }

        public void Register(Type interfaceType, Type implType, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            this.dependency.Register(interfaceType, implType, lifeTime);
        }

        public void Register<TInterface, TImpl>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            this.dependency.Register<TInterface, TImpl>(dependencyLifeTime);
        }

        public void Register(System.Reflection.Assembly assembly, Func<Type, bool> predicate, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            this.dependency.Register(assembly, predicate, lifeTime);
        }

        public void Register(System.Reflection.Assembly interfaceAssembly, System.Reflection.Assembly implAssembly, Func<Type, bool> predicate, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            this.dependency.Register(interfaceAssembly, implAssembly, predicate);
        }

        public object Resolver(Type type)
        {
            return this.dependency.Resolver(type);
        }

        public T Resolver<T>()
        {
            return this.dependency.Resolver<T>();
        }

        public bool IsRegisted(Type type)
        {
            return this.dependency.IsRegisted(type);
        }

        public void Dispose()
        {
            this.dependency.Dispose();
        }

    }
}
