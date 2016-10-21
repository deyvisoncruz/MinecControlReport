using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecControlReport.Models;
using MinecControlReport.Models;

namespace MinecControlReport.Controllers
{
    public class HomeController : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();
        private List<menuList> ml = new List<menuList>();
        private List<menu> m = new List<menu>();
        private List<subMenuList> subml = new List<subMenuList>();
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

        public ActionResult MenuList()
        {
           var queryMenu = db.menu.OrderBy(p=>p.Order);
           string dinamicMenu = "";
           foreach (menu c in queryMenu)
           {
               dinamicMenu += "<li><a href='"+c.Link+"'>"+c.Name+"</a>";
               var queryReport = db.menuReport.Where(p => p.MenuRefId == c.Id).OrderBy(p => p.Order);
               if (queryReport.Count() > 0)
               {
                   dinamicMenu += "<ul>";
                   foreach (menuReport r in queryReport)
                   {
                       dinamicMenu += "<li><a href='" + r.Link + "'>" + r.Name + "</a></li>";
                   }

                   dinamicMenu += "</ul>";
               }
               dinamicMenu += "</li>";
           }
           ViewBag.menu = dinamicMenu;
           return PartialView();
        }

      
    }
}
