using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecControlReport.Models;
using MinecControlReport.Models;
using MinecControlReport.Filters;
using System.Web.Security;

namespace MinecControlReport.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();
        private List<menuList> ml = new List<menuList>();
        private List<menu> m = new List<menu>();
        private List<subMenuList> subml = new List<subMenuList>();


        public ActionResult Index(string Id = "metas", string type="1")
        {

            ViewBag.Message = "Bem vindo ao módulo de relatórios!";
           // Id = Id.Replace(" ","
            if (Id != "metas")
            {
                if (type == "1")
                    ViewBag.Report = "http://localhost:2672/Reports/ReportView.aspx?report=" + Id;
                else
                    ViewBag.Report = "http://localhost/MC/reports/" + Id+ ".aspx"; ;
            }
            else
            {
                ViewBag.Report = "http://localhost:2672/Reports/ReportView.aspx?report=" + Id;
            }


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
            string url = "http://localhost:2672";
            var rolesArray = Roles.GetRolesForUser();
            List<int> listMenuId = new List<int>();
           
            foreach (string s in rolesArray)
            {
                
                listMenuId.AddRange(db.menuRole.Where(p => p.RolesRef == s).Select(p =>p.MenuRefId));
               
            }
            foreach (menu c in queryMenu)
           {


               if (listMenuId.Contains(c.Id))
               {
                   dinamicMenu += "<li><a href='" + c.Link + "'>" + c.Name + "</a>";
                   var queryReport = db.menuReport.Where(p => p.MenuRefId == c.Id).OrderBy(p => p.Order);
                   if (queryReport.Count() > 0)
                   {
                       dinamicMenu += "<ul>";
                       foreach (menuReport r in queryReport)
                       {
                          
                                dinamicMenu += "<li><a href='" + url + "/home/index/" + r.Link + "/" + r.type + "'>" + r.Name + "</a></li>";
                         

                       }

                       dinamicMenu += "</ul>";
                   }
                   dinamicMenu += "</li>";
               }
           }
           ViewBag.menu = dinamicMenu;
           return PartialView();
        }

      
    }
}
