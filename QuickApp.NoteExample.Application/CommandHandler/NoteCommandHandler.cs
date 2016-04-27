/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/27 星期三 14:31:36
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Application;
using QuickApp.Commands;
using QuickApp.NoteExample.Application.Command;
using QuickApp.NoteExample.Domain.Model;
using QuickApp.NoteExample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.NoteExample.Application.CommandHandler
{
    /// <summary>
    /// <see cref="NoteCommandHandler"/>
    /// </summary>
    public class NoteCommandHandler:ApplicationService
    {
        private readonly INoteInfoRepository noteInfoRepository;
        public NoteCommandHandler(INoteInfoRepository noteInfoRepository)
        {
            this.noteInfoRepository = noteInfoRepository;
        }

        [CommandExecuteAttribute(typeof(CreateNoteInfoCommand))]
        public bool CreateNoteInfoCommand(CreateNoteInfoCommand createNoteInfoCommand)
        {
            NoteInfo noteInfo = new NoteInfo(createNoteInfoCommand.NoteInfo.Title,createNoteInfoCommand.NoteInfo.NoteContent);

            this.noteInfoRepository.Add(noteInfo);

            return true;
        }

        [CommandExecuteAttribute(typeof(EditNoteInfoCommand))]
        public void EditNoteInfoCommand(EditNoteInfoCommand editNoteInfoCommand)
        {
            NoteInfo noteInfo = (NoteInfo)editNoteInfoCommand.NoteInfo.Mapping();

            this.noteInfoRepository.Update(noteInfo);
        }

        [CommandExecuteAttribute(typeof(DeleteNoteInfoCommand))]
        public void DeleteNoteInfoCommand(DeleteNoteInfoCommand deleteNoteInfoCommand)
        {
            this.noteInfoRepository.Delete(this.noteInfoRepository.GetById(deleteNoteInfoCommand.ID));
        }
    }
}
