/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:45:46
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.Common.Test.Domain.Reposities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.Reposities
{
    /// <summary>
    /// <see cref="PersonInfoRepositoryTest"/>
    /// </summary>
    [TestClass]
    public class PersonInfoRepositoryTest : TestBase
    {
        [TestMethod]
        public void AddPersonInfoTest()
        {
            IRepositoryContextManager repositoryContextManager = base.app.DependencyContainer.Resolver<IRepositoryContextManager>();
            IRepositoryContext repositoryContext = repositoryContextManager.Create();
            IRepository<PersonInfo> personInfoRepository = base.app.DependencyContainer.Resolver<IRepository<PersonInfo>>();
            PersonInfo personInfo = new PersonInfo();
            personInfo.ID = Guid.NewGuid();
            personInfo.UserName = "FRind";
            personInfo.Age = 21;
            personInfoRepository.Add(personInfo);
            repositoryContext.Commit();
        }
    }
}
