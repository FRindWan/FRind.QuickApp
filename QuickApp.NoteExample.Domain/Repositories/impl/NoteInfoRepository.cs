/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:38:05
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Data;
using QuickApp.NoteExample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Domain.Repositories.impl
{
    /// <summary>
    /// <see cref="NoteInfoRepository"/>
    /// </summary>
    public class NoteInfoRepository : QuickDataRepository<NoteInfo>, INoteInfoRepository
    {
    }
}
