/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 17:52:08
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
    /// <see cref="EditNoteInfoCommand"/>
    /// </summary>
    public class EditNoteInfoCommand:Commands.Command
    {
        public EditNoteInfoCommand(NoteInfoDto noteInfoDto)
        {
            this.NoteInfo = noteInfoDto;
        }

        public NoteInfoDto NoteInfo { get; private set; }
    }
}
