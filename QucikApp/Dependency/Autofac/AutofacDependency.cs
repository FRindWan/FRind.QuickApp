/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 16:34:59
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy2;
using Castle.DynamicProxy;
using QucikApp.Dependency.Interceptors;

namespace QucikApp.Dependency.Autofac
{
    /// <summary>
    /// <see cref="AutofacDependency"/>
    /// </summary>
    internal class AutofacDependency:IDependency
    {
        private IContainer container;
        private ContainerBuilder builder;
        private bool isBuild;
        private RegisterInterceptorService autofacRegisterInterceptorService;

        public AutofacDependency()
        {
            this.builder = new ContainerBuilder();
            this.isBuild = false;
            this.autofacRegisterInterceptorService = RegisterInterceptorService.Instance;
        }

        public void Register(Type type, DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            this.builder.RegisterType(type).AsSelf().SetLifeTime(dependencyLifeTime);
        }

        public void Register<Type>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            this.builder.RegisterType<Type>().AsSelf().SetLifeTime(dependencyLifeTime);
        }

        public void Register(Type interfaceType, Type implType, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            var registerBuilder=this.builder.RegisterType(implType).As(interfaceType).SetLifeTime(lifeTime);
            this.autofacRegisterInterceptorService.Register(registerBuilder, interfaceType, implType);
        }

        public void Register<TInterface, TImpl>(DependencyLifeTime dependencyLifeTime = DependencyLifeTime.Transient)
        {
            var registerBuilder = this.builder.RegisterType<TImpl>().As<TInterface>().AsImplementedInterfaces().SetLifeTime(dependencyLifeTime);
            this.autofacRegisterInterceptorService.Register(registerBuilder, typeof(TInterface), typeof(TImpl));
        }

        public void Register(System.Reflection.Assembly assembly, Func<Type, bool> predicate=null, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            if (predicate != null)
            {
                this.builder.RegisterAssemblyTypes(assembly).Where(predicate).AsImplementedInterfaces().SetLifeTime(lifeTime);
            }
            else
            {
                this.builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().SetLifeTime(lifeTime);
            }

        }

        public void Register(System.Reflection.Assembly interfaceAssembly, System.Reflection.Assembly implAssembly, Func<Type, bool> predicate=null, DependencyLifeTime lifeTime = DependencyLifeTime.Transient)
        {
            if (predicate != null)
            {
                this.builder.RegisterAssemblyTypes(interfaceAssembly, implAssembly).Where(predicate).AsImplementedInterfaces().SetLifeTime(lifeTime);
            }
            else
            {
                this.builder.RegisterAssemblyTypes(interfaceAssembly, implAssembly).AsImplementedInterfaces().SetLifeTime(lifeTime);
            }
        }

        public object Resolver(Type type)
        {
            return this.Build().Resolve(type);
        }

        public T Resolver<T>()
        {
            return this.Build().Resolve<T>();
        }

        public bool IsRegisted(Type type)
        {
            return this.Build().IsRegistered(type);
        }

        public void Dispose()
        {
            this.container.Dispose();
            this.container = null;
            this.builder = null;
        }

        private IContainer Build()
        {
            if (!this.isBuild)
            {
                this.container = this.builder.Build();
                this.isBuild = true;
            }

            return this.container;
        }

    }
}
