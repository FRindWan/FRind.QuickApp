using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickApp.NoteExample.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryContextManager context;

        public HomeController(IRepositoryContextManager context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            ViewBag.RepositoryContext = context.GetType().Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}