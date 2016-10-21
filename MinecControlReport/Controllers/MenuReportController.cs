using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecControlReport.Models;
using MinecControlReport.Models;

namespace MinecControlReport.Controllers
{
    public class MenuReportController : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();

        //
        // GET: /MenuReport/

        public ActionResult Index()
        {
            var menureport = db.menuReport.Include(m => m.menu);
            return View(menureport.ToList());
        }

        //
        // GET: /MenuReport/Details/5

        public ActionResult Details(int id = 0)
        {
            menuReport menureport = db.menuReport.Find(id);
            if (menureport == null)
            {
                return HttpNotFound();
            }
            return View(menureport);
        }

        //
        // GET: /MenuReport/Create

        public ActionResult Create()
        {
            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name");
            return View();
        }

        //
        // POST: /MenuReport/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(menuReport menureport)
        {
            if (ModelState.IsValid)
            {
                db.menuReport.Add(menureport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name", menureport.MenuRefId);
            return View(menureport);
        }

        //
        // GET: /MenuReport/Edit/5

        public ActionResult Edit(int id = 0)
        {
            menuReport menureport = db.menuReport.Find(id);
            if (menureport == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name", menureport.MenuRefId);
            return View(menureport);
        }

        //
        // POST: /MenuReport/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(menuReport menureport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menureport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuRefId = new SelectList(db.menu, "Id", "Name", menureport.MenuRefId);
            return View(menureport);
        }

        //
        // GET: /MenuReport/Delete/5

        public ActionResult Delete(int id = 0)
        {
            menuReport menureport = db.menuReport.Find(id);
            if (menureport == null)
            {
                return HttpNotFound();
            }
            return View(menureport);
        }

        //
        // POST: /MenuReport/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            menuReport menureport = db.menuReport.Find(id);
            db.menuReport.Remove(menureport);
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