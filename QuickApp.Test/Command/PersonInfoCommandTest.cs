/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 15:57:34
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp.Commands;
using QuickApp.Common.Test.Command;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.Data.Infrastructure;
using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.Command
{
    /// <summary>
    /// <see cref="PersonInfoCommandTest"/>
    /// </summary>
    [TestClass]
    public class PersonInfoCommandTest:TestBase
    {
        private CommandExecuter commandExecuter;

        public PersonInfoCommandTest()
        {
            this.commandExecuter = this.app.DependencyContainer.Resolver<CommandExecuter>();
        }

        [TestMethod]
        public void TestAddPersonInfoCommand()
        {
            IRepositoryContextManager dbContext = this.app.DependencyContainer.Resolver<IRepositoryContextManager>();
            dbContext.Create();

            commandExecuter.ExecuteAsync(new AddPersonCommand()
            {
                PersonInfo = new PersonInfo()
                {
                    ID = Guid.NewGuid(),
                    Age = 22,
                    UserName = "FRind"
                }
            });

            Console.WriteLine("ddd");


        }
    }
}
