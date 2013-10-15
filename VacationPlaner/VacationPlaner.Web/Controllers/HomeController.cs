using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VacationPlaner.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //ViewData["Message"] = "Modify this template to jump-start your ASP.NET MVC application.";
            //ViewData.Model
            return View(model: "Model data!");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult About2()
        {
            ViewBag.Message = "Your app description page 2.";

            return View();
        }

    }
}
