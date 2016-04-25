/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 14:56:48
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace QuickApp.Other.Test
{
    /// <summary>
    /// <see cref="ReflectionTest"/>
    /// </summary>
    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Stopwatch methodSW = new Stopwatch();
            Object personInfo=new PersonInfo();


            methodSW.Start();
            //personInfo.SayHello("Wan");
            methodSW.Stop();
            Console.WriteLine(String.Format("used time : {0}", methodSW.Elapsed.TotalMilliseconds));

            methodSW.Restart();
            MethodInfo methodInfo = typeof(PersonInfo).GetMethod("SayHello");
            methodInfo.Invoke(personInfo, new object[] { "FRind" });
            Console.WriteLine(methodInfo.ReflectedType);
            methodSW.Stop();
            Console.WriteLine(String.Format("Method used time : {0}", methodSW.Elapsed.TotalMilliseconds));

        }

        [TestMethod]
        public void TestOther()
        {
            Console.WriteLine(this.GetHashCode());
        }
    }

    public class PersonInfo
    {
        public void SayHello(String name)
        {
            Console.WriteLine(String.Format("Hello {0}", name));
            System.Threading.Thread.Sleep(1);
        }
    }
}
