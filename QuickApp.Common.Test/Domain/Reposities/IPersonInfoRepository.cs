/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:30:13
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Repository;
using QuickApp.Common.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Domain.Reposities
{
    /// <summary>
    /// <see cref="IPersonInfoRepository"/>
    /// </summary>
    public interface IPersonInfoRepository:IRepository<PersonInfo>
    {
    }
}
