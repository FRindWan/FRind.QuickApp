/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:49:23
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Application;
using QuickApp.NoteExample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Application.Dto
{
    /// <summary>
    /// <see cref="NoteInfoDto"/>
    /// </summary>
    public class NoteInfoDto:DtoBase
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string NoteContent { get; set; }

        public DateTime CreateTime { get; set; }


        public override IDto Mapping(QuickApp.Domain.Entites.IEntity model)
        {
            NoteInfo noteInfo = (NoteInfo)model;
            this.ID = noteInfo.ID;
            this.Title = noteInfo.Title;
            this.NoteContent = noteInfo.NoteContent;
            this.CreateTime = noteInfo.CreateTime;

            return this;
        }

        public override QuickApp.Domain.Entites.IEntity Mapping()
        {
            NoteInfo noteInfo = new NoteInfo();
            noteInfo.ID = this.ID;
            noteInfo.Title = this.Title;
            noteInfo.NoteContent = this.NoteContent;
            noteInfo.CreateTime = this.CreateTime;

            return noteInfo;
        }
    }
}
