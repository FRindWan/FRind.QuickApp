/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/19 星期二 14:56:24
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp.Common.Test.Domain.Events;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.Common.Test.Domain.Reposities;
using QuickApp.Domain.Specifications;
using QuickApp.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.Events
{
    /// <summary>
    /// <see cref="PersonInfoNameChangedEventTest"/>
    /// </summary>
    [TestClass]
    public class PersonInfoNameChangedEventTest:TestBase
    {
        [TestMethod]
        public void TestPersonInfoNameChangedEvent()
        {
            IPersonInfoRepository personInfoRepository = this.app.DependencyContainer.Resolver<IPersonInfoRepository>();
            PersonInfo personInfo = personInfoRepository.Get(Specification<PersonInfo>.Eval(p => p.UserName == "FRind"));
            if (personInfo == null)
            {
                Assert.Fail("获取PersonInfo信息失败！");
                return;
            }

            Console.WriteLine(personInfo.UserName);

            personInfo.UserName = "万彬";
            IEventAggregator eventAggregator = this.app.DependencyContainer.Resolver<IEventAggregator>();
            eventAggregator.Published(new PersonInfoNameChangedEvent() { PersonInfo = personInfo });

        }
    }
}
