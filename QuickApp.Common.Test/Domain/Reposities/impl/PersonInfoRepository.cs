/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:32:18
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.UnitOfWorks;
using QuickApp.Common.Test.Domain.Model;
using QuickApp.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Domain.Reposities.impl
{
    /// <summary>
    /// <see cref="PersonInfoRepository"/>
    /// </summary>
    public class PersonInfoRepository:EFRepository<PersonInfo>,IPersonInfoRepository
    {
        public PersonInfoRepository(ICurrentRepositoryContextProvider currentRepositoryContextProvider)
            : base(currentRepositoryContextProvider)
        { 
        }
    }
}
