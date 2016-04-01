/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 17:06:32
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QucikApp;
using QucikApp.Dependency;
using QucikApp.Dependency.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.Dependency
{
    /// <summary>
    /// <see cref="AutofacDependencyTest"/>
    /// </summary>
    [TestClass]
    public class AutofacDependencyTest
    {
        private IQuickApp quickApp;

        public AutofacDependencyTest()
        {
            this.quickApp = new DefaultQuickApp();
            this.quickApp.Initialize();
        }

        [TestMethod]
        public void TestDependencyRegisterIsResolver()
        {
            IDependency dependency1 = this.quickApp.DependencyContainer.Resolver<IDependency>();
            IDependency dependency2 = this.quickApp.DependencyContainer.Resolver<IDependency>();
            Assert.AreEqual(this.quickApp.DependencyContainer,dependency2);
        }
    }
}
