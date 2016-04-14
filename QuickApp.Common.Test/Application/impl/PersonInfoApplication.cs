/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 10:39:55
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Application;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.Common.Test.Domain.Reposities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Application.impl
{
    /// <summary>
    /// <see cref="PersonInfoApplication"/>
    /// </summary>
    public class PersonInfoApplication:ApplicationService,IPersonInfoApplication
    {
        private readonly IPersonInfoRepository personInfoRepository;

        public PersonInfoApplication(IPersonInfoRepository personInfoRepository)
        {
            this.personInfoRepository = personInfoRepository;
        }

        public void AddPersonInfo(string name, int age)
        {
            PersonInfo personInfo = new PersonInfo();
            personInfo.UserName = name;
            personInfo.Age = age;

            this.personInfoRepository.Add(personInfo);
        }
    }
}
