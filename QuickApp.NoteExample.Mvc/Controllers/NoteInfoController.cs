using QuickApp.Commands;
using QuickApp.Mvc;
using QuickApp.NoteExample.Application.Command;
using QuickApp.NoteExample.Application.Dto;
using QuickApp.NoteExample.Application.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickApp.NoteExample.Mvc.Controllers
{
    public class NoteInfoController:QuickAppControllerBase
    {
        private INoteInfoQuery noteInfoQuery;

        public NoteInfoController(INoteInfoQuery noteInfoQuery)
        {
            this.noteInfoQuery = noteInfoQuery;
        }

        public ActionResult Index()
        {
            ViewBag.Page = this.noteInfoQuery.GetPaged();

            return View();
        }

        public ActionResult Details(Guid id)
        {
            return View(this.noteInfoQuery.Get(id));
        }

        public ActionResult Delete(Guid id)
        {
            this.CommandExecuter.Execute(new DeleteNoteInfoCommand(id));

            return RedirectToAction("index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(this.noteInfoQuery.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(NoteInfoDto noteInfo)
        {
            if (noteInfo == null)
            {
                ViewBag.Error = "修改的数据不能为空！";
                return View();
            }

            this.CommandExecuter.Execute(new EditNoteInfoCommand(noteInfo));

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NoteInfoDto noteInfo)
        {
            if (noteInfo == null)
            {
                ViewBag.Error = "添加的数据不能为空！";
                return View();
            }

            object result=this.CommandExecuter.Execute(new CreateNoteInfoCommand(noteInfo));


            return RedirectToAction("index");
        }
    }
}