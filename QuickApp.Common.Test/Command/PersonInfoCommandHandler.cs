/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/20 星期三 17:02:45
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Commands;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.Common.Test.Domain.Reposities;
using QuickApp.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Command
{
    /// <summary>
    /// <see cref="PersonInfoCommandHandler"/>
    /// </summary>
    public class PersonInfoCommandHandler
    {
         private readonly IPersonInfoRepository personInfoRepository;

         public PersonInfoCommandHandler(IPersonInfoRepository personInfoRepository)
        {
            this.personInfoRepository = personInfoRepository;
        }

        [CommandExecute(typeof(AddPersonCommand))]
        public void AddPersonInfoCommand(AddPersonCommand command)
        {
            this.personInfoRepository.Add(((AddPersonCommand)command).PersonInfo);
        }

        [CommandExecute(typeof(AddPersonListCommand))]
        public void AddPersonInfoCommand(AddPersonListCommand command)
        {
            IList<PersonInfo> personInfoList = command.PersonInfoList;
            foreach (PersonInfo personInfo in personInfoList)
            {
                this.personInfoRepository.Add(personInfo);
            }
            
        }

        [CommandExecute(typeof(GetPersonCommand))]
        public PersonInfo GetPersonInfoCommand(GetPersonCommand command)
        {
            return this.personInfoRepository.Get(Specification<PersonInfo>.Eval(p => p.UserName == command.Name));
        }
    }
}
