using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecControlReport.Models;
using MinecControlReport.Filters;
using System.Web.Security;

namespace MinecControlReport.Controllers
{
    //[Authorize]
    [InitializeSimpleMembership]
    public class MenuRoleController : Controller
    {
        
        private MineControlReportContext db = new MineControlReportContext();

        //
        // GET: /MenuRole/

        public ActionResult Index()
        {
          try
            {
                var roles = Roles.GetAllRoles();
                SelectList list2 = new SelectList(roles);
                ViewBag.Roles = list2;
                var menurole = db.menuRole.Include(m => m.menu);
                return View(menurole.ToList());
            }
            catch 
            {

                return View();
            }
        }

        //
        // GET: /MenuRole/Details/5

        public ActionResult Details(int id = 0)
        {
            
            menuRole menurole = db.menuRole.Find(id);
            if (menurole == null)
            {
                return HttpNotFound();
            }
            var roles = Roles.GetAllRoles();
            SelectList list2 = new SelectList(roles);

            ViewBag.RoleRef = list2.Where(p => p.Value == menurole.RolesRef);
            return View(menurole);
        }

        //
        // GET: /MenuRole/Create

        public ActionResult Create()
        {
            var roles = Roles.GetAllRoles();
            SelectList list2 = new SelectList(roles);
            ViewBag.Roles = list2;
            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name");
            return View();
        }

        //
        // POST: /MenuRole/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(menuRole menurole)
        {
            if (ModelState.IsValid)
            {
                db.menuRole.Add(menurole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var roles = Roles.GetAllRoles();
            SelectList list2 = new SelectList(roles);
            ViewBag.Roles = list2;
            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name", menurole.MenuRefId);
            return View(menurole);
        }

        //
        // GET: /MenuRole/Edit/5

        public ActionResult Edit(int id = 0)
        {
            menuRole menurole = db.menuRole.Find(id);
            if (menurole == null)
            {
                return HttpNotFound();
            }
            var roles = Roles.GetAllRoles();
            SelectList list2 = new SelectList(roles);
            ViewBag.Roles = list2;
            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name", menurole.MenuRefId);
            return View(menurole);
        }

        //
        // POST: /MenuRole/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(menuRole menurole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menurole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var roles = Roles.GetAllRoles();
            SelectList list2 = new SelectList(roles);
            ViewBag.Roles = list2;
            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name", menurole.MenuRefId);
            return View(menurole);
        }

        //
        // GET: /MenuRole/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var roles = Roles.GetAllRoles();
            SelectList list2 = new SelectList(roles);
            ViewBag.Roles = list2;
            menuRole menurole = db.menuRole.Find(id);
            if (menurole == null)
            {
                return HttpNotFound();
            }
            return View(menurole);
        }

        //
        // POST: /MenuRole/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var roles = Roles.GetAllRoles();
            SelectList list2 = new SelectList(roles);
            ViewBag.Roles = list2;
            menuRole menurole = db.menuRole.Find(id);
            db.menuRole.Remove(menurole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}