/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/11 星期一 14:38:57
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QucikApp;
using QucikApp.Dependency;
using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using QuickApp.EntityFramework.Repository;
using QuickApp.EntityFramework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.UnitOfWork
{
    /// <summary>
    /// <see cref="EFUnitOfWorkTest"/>
    /// </summary>
    [TestClass]
    public class EFUnitOfWorkTest
    {
        private IQuickApp app;

        public EFUnitOfWorkTest()
        {
            this.app = new DefaultQuickApp();
            this.app.Initialize();
            this.app.DependencyContainer.Register<IUnitOfWork, EFUnitOfWork>();
            this.app.DependencyContainer.Register<IUnitOfWorkManager, UnitOfWorkManager>();
            this.app.DependencyContainer.Register<ICurrentUnitOfWorkProvider, CurrentUnitOfWorkProvider>();
            this.app.DependencyContainer.Register(typeof(IRepository<,>),typeof(EFRepository<,,>)));
            this.app.DependencyContainer.Register<IDependency, DependencyProxy>();
        }

        [TestMethod]
        public void TestRepository()
        { 
            
        }
    }
}
