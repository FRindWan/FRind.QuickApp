/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 10:38:36
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp.Common.Test.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.Application
{
    /// <summary>
    /// <see cref="PersonInfoApplicationTest"/>
    /// </summary>
    [TestClass]
    public class PersonInfoApplicationTest:TestBase
    {
        [TestMethod]
        public void TestAddPersonInfoApplication()
        {
            IPersonInfoApplication personInfoApplication = this.app.DependencyContainer.Resolver<IPersonInfoApplication>();
            personInfoApplication.AddPersonInfo("万彬", 21);

            
        }
    }
}
