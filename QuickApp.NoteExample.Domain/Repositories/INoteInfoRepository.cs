/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:37:49
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Repository;
using QuickApp.NoteExample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Domain.Repositories
{
    /// <summary>
    /// <see cref="INoteInfoRepository"/>
    /// </summary>
    public interface INoteInfoRepository:IRepository<NoteInfo>
    {
    }
}
