/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 12:02:05
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QucikApp;
using QucikApp.Dependency;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.UnitOfWork
{
    /// <summary>
    /// <see cref="UnitOfWorkTest"/>
    /// </summary>
    [TestClass]
    public class UnitOfWorkTest
    {
        private IQuickApp app;
        private IUnitOfWork unitOfWork;

        public UnitOfWorkTest()
        {
            this.app = new DefaultQuickApp();
            this.app.Initialize();
            this.app.DependencyContainer.Register<IRepositoryContextManager, RepositoryContextManager>();
            this.app.DependencyContainer.Register<ICurrentRepositoryContextProvider, CurrentRepositoryContextProvider>();
        }

        [TestMethod]
        public void TestGetUnitOfWork()
        {
            IUnitOfWork unitOfWork = this.app.DependencyContainer.Resolver<IUnitOfWork>();
            Assert.IsNotNull(unitOfWork.Id);
        }
    }
}
