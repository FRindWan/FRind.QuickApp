/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 16:49:40
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Infrastructure;
using QuickApp.NoteExample.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Application.Query
{
    /// <summary>
    /// <see cref="INoteInfoQuery"/>
    /// </summary>
    public interface INoteInfoQuery
    {
        IPaged<NoteInfoDto> GetPaged();

        NoteInfoDto Get(Guid noteInfoID);

        Int32 GetCount();
    }
}
