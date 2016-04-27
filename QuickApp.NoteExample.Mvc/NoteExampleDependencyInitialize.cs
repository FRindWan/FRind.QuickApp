using QuickApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace QuickApp.NoteExample.Mvc
{
    public class NoteExampleDependencyInitialize:DependencyInitialize
    {
        public override void InitializeInterceptor(Dependency.Autofac.RegisterInterceptorService registerInterceptorService)
        {
            
        }

        public override void InitializeDependency(IDependencyRegister dependency)
        {
            dependency.Register(Assembly.Load("QuickApp.NoteExample.Domain"));
            dependency.Register(Assembly.Load("QuickApp.NoteExample.Application"));
        }
    }
}