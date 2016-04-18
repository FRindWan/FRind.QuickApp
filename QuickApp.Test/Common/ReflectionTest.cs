/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/18 星期一 11:28:50
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp.Common.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.Common
{
    /// <summary>
    /// <see cref="ReflectionTest"/>
    /// </summary>
    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void TestReflectionFindInterfaceAndClassForAssembly()
        {
            var assembly = Assembly.Load("QuickApp.Common.Test");
            var quickAppAssembly = Assembly.Load("QuickApp");
            IDictionary<Type, Type> typeDictionary = ReflectionExtension.GetAllInterfaceAndClassForAssembly(assembly, null,quickAppAssembly);
            if (typeDictionary == null || typeDictionary.Count <= 0)
            {
                Assert.Fail("未获取到任何相关信息！");
                return;
            }

            foreach (KeyValuePair<Type, Type> item in typeDictionary)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
