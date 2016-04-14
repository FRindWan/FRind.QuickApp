/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 14:32:39
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy2;

namespace QuickApp.Other.Test
{
    /// <summary>
    /// <see cref="AutofacInterceptorTest"/>
    /// </summary>
    [TestClass]
    public class AutofacInterceptorTest
    {
        [TestMethod]
        public void TestAutofacInterceptor()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<PersonInfoService>().AsSelf().EnableClassInterceptors().InterceptedBy(typeof(RepositoryContextInterceptor));
            builder.RegisterType<RepositoryContextInterceptor>();
            IContainer container = builder.Build();
            PersonInfoService personInfoService = container.Resolve<PersonInfoService>();
            personInfoService.Print("FRind");
        }
    }

    public interface IPersonInfoService
    {
        void Print(String name);
    }

    public class PersonInfoService
    {
        public virtual void Print(string name)
        {
            Console.WriteLine("帅哥：" + name);
        }
    }

}
