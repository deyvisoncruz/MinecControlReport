using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecControlReport.Models;
using MineControlReport.Models;

namespace MinecControlReport.Controllers
{
    public class Default1Controller : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.PeriodTime.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            kpis kpis = db.PeriodTime.Find(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kpis kpis)
        {
            if (ModelState.IsValid)
            {
                db.PeriodTime.Add(kpis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kpis);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            kpis kpis = db.PeriodTime.Find(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(kpis kpis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kpis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kpis);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            kpis kpis = db.PeriodTime.Find(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kpis kpis = db.PeriodTime.Find(id);
            db.PeriodTime.Remove(kpis);
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