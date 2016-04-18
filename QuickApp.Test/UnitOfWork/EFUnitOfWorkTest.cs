/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/11 星期一 14:38:57
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp;
using QuickApp.Dependency;
using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using QuickApp.EntityFramework.Repository;
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
            this.app.DependencyContainer.Register<IRepositoryContextManager, RepositoryContextManager>();
            this.app.DependencyContainer.Register<ICurrentRepositoryContextProvider, CurrentRepositoryContextProvider>();
            this.app.DependencyContainer.Register(typeof(IRepository<,>),typeof(EFRepository<,>));
        }

        [TestMethod]
        public void TestRepository()
        { 
            
        }
    }
}
