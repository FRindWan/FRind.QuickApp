/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 16:54:46
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Common.Config;
using QuickApp.Common.Config.impl;
using QuickApp.Config.impl;
using QuickApp.Dependency;
using QuickApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Config
{
    /// <summary>
    /// <see cref="ConfigSource"/>
    /// </summary>
    public class ConfigSource:IConfigSource
    {
        public readonly static IConfigSource Instance;

        static ConfigSource()
        { 
            Instance=new ConfigSource();
        }

        private readonly IDependencyConfigSource dependencyConfigSource;
        private readonly IEventConfigSource eventConfigSource;
        private readonly ICommandConfigSource commandConfigSource;
        private readonly IRepositoryConfigSource repositoryConfigSource;
        private readonly IWebConfigSource webConfigSource;
        private readonly IDependencyResolver resolver;

        private ConfigSource()
        {
            this.dependencyConfigSource = new DependencyConfigSource();
            this.eventConfigSource = new EventConfigSource();
            this.commandConfigSource = new CommandConfigSource();
            this.repositoryConfigSource = new RepositoryConfigSource();
            this.webConfigSource = new WebConfigSource();
            this.resolver = Dependency.DependencyFactory.GetDependency();
        }

        public IDependencyConfigSource DependencyConfigSource { get { return this.dependencyConfigSource; } }


        public IEventConfigSource EventConfigSource { get { return this.eventConfigSource; } }

        public Common.Config.ICommandConfigSource CommandConfigSource { get { return this.commandConfigSource; } }

        public Common.Config.IRepositoryConfigSource RepositoryConfigSource { get { return this.repositoryConfigSource; } }

        public Common.Config.IWebConfigSource WebConfigSource { get { return this.webConfigSource; } }

        public IDependencyResolver DependencyResolver { get { return this.resolver; } }

        public IConfigSource AddDependInitialize(DependencyInitialize dependencyInitialize)
        {
            if (dependencyInitialize != null)
            {
                DependencyInitializeService.AddDependencyInitialize(dependencyInitialize);
            }

            return this;
        }

        public IConfigSource AddCommandScanAssembly(params Assembly[] assemblys)
        {
            this.commandConfigSource.SetAssembly(assemblys);

            return this;
        }

        public IConfigSource SetDbInfo(Type dbContextType,Type dbContextImplType, DataBaseType dbType)
        {
            this.repositoryConfigSource.DbContextType = dbContextType;
            this.repositoryConfigSource.DbContextImplType = dbContextImplType;
            this.repositoryConfigSource.DbType = dbType;

            return this;
        }

        public IQuickApp Initialize()
        {
            IQuickApp quickApp = new DefaultQuickApp();
            quickApp.Initialize();

            return quickApp;
        }
    }
}
