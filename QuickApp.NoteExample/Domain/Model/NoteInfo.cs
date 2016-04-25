/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/21 星期四 10:41:33
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Domain.Model
{
    /// <summary>
    /// <see cref="NoteInfo"/>
    /// </summary>
    public class NoteInfo:Entity
    {
        public String Title { get; set; }
    }
}
