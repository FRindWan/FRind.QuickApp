/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:48:18
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.NoteExample.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Application.Command
{
    /// <summary>
    /// <see cref="CreateNoteInfoCommand"/>
    /// </summary>
    public class CreateNoteInfoCommand:Commands.Command
    {
        public NoteInfoDto NoteInfo { get; private set; }

        public CreateNoteInfoCommand(NoteInfoDto noteInfo)
        {
            this.NoteInfo = noteInfo;
        }
    }
}
