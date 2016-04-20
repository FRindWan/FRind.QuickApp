/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:52:32
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp;
using QuickApp.Dependency;
using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using QuickApp.Common.Test.Application;
using QuickApp.Common.Test.Application.impl;
using QuickApp.Common.Test.Domain.Reposities;
using QuickApp.Common.Test.Domain.Reposities.impl;
using QuickApp.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test
{
    /// <summary>
    /// <see cref="Gobal"/>
    /// </summary>
    public class TestBase
    {
        protected IQuickApp app;

        public TestBase()
        {
            DependencyInitializeService.AddDependencyInitialize(new QuickAppTestDependencyInitialize());

            this.app = new DefaultQuickApp();
            this.app.ConfigSource.EventConfigSource.SetAssembly(Assembly.Load("QuickApp.Common.Test"));
            this.app.ConfigSource.CommandConfigSource.SetAssembly(Assembly.Load("QuickApp.Common.Test"));

            this.app.Initialize();
        }
    }
}
