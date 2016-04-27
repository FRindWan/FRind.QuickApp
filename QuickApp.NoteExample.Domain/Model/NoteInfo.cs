/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:32:19
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Domain.Model
{
    /// <summary>
    /// <see cref="NoteInfo"/>
    /// </summary>
    [Table("TNoteInfo")]
    public class NoteInfo : AggregateRoot
    {
        public NoteInfo()
        { }

        public NoteInfo(string title, string noteContent)
        {
            this.ID = Guid.NewGuid();
            this.Title = title;
            this.NoteContent = noteContent;
            this.CreateTime = DateTime.Now;
        }

        public string Title { get; set; }

        public string NoteContent { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
