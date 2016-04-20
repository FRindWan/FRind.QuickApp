/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/14 星期四 10:39:55
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Application;
using QuickApp.Commands;
using QuickApp.Common.Test.Command;
using QuickApp.Common.Test.Domain.Events;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.Common.Test.Domain.Reposities;
using QuickApp.Eventing;
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
    public class PersonInfoApplication : ApplicationService, IPersonInfoApplication, IEventHandler<PersonInfoNameChangedEvent>
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

        [CommandExecute(typeof(AddPersonCommand))]
        public int AddPersonInfoCommand(AddPersonCommand command)
        {
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(1);
            return 1;
            //this.personInfoRepository.Add(((AddPersonCommand)command).PersonInfo);
        }

        public void Handle(PersonInfoNameChangedEvent @event)
        {
            //PersonInfo personInfo = this.personInfoRepository.GetById(@event.PersonInfo.ID);
            //personInfo.UserName = @event.PersonInfo.UserName;

            this.personInfoRepository.Update(@event.PersonInfo);
        }
    }
}
