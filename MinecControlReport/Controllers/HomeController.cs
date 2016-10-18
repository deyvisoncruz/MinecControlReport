using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinecControlReport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bem vindo ao módulo de relatórios!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Fast2Mine";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contato";

            return View();
        }
    }
}
