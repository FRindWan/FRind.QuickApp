/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 18:30:27
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Application.Command
{
    /// <summary>
    /// <see cref="DeleteNoteInfoCommand"/>
    /// </summary>
    public class DeleteNoteInfoCommand:Commands.Command
    {
        public DeleteNoteInfoCommand(Guid id)
        {
            this.ID = id;
        }

        public Guid ID { get; private set; }
    }
}
