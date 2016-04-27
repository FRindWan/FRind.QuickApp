/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 17:28:37
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Application
{
    /// <summary>
    /// <see cref="DtoBase"/>
    /// </summary>
    public abstract class DtoBase:IDto
    {
        public abstract IDto Mapping(IEntity model);

        public abstract IEntity Mapping();
    }
}
