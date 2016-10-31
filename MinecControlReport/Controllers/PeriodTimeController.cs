using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinecControlReport.Models;

namespace MinecControlReport.Controllers
{
    public class PeriodTimeController : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();

        //
        // GET: /PeriodTime/

        public ActionResult Index()
        {
            return View(db.periodTime.ToList());
        }

        //
        // GET: /PeriodTime/Details/5

        public ActionResult Details(int id = 0)
        {
            PeriodTime periodtime = db.periodTime.Find(id);
            if (periodtime == null)
            {
                return HttpNotFound();
            }
            return View(periodtime);
        }

        //
        // GET: /PeriodTime/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PeriodTime/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeriodTime periodtime)
        {
            if (ModelState.IsValid)
            {
                db.periodTime.Add(periodtime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodtime);
        }

        //
        // GET: /PeriodTime/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PeriodTime periodtime = db.periodTime.Find(id);
            if (periodtime == null)
            {
                return HttpNotFound();
            }
            return View(periodtime);
        }

        //
        // POST: /PeriodTime/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PeriodTime periodtime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodtime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodtime);
        }

        //
        // GET: /PeriodTime/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PeriodTime periodtime = db.periodTime.Find(id);
            if (periodtime == null)
            {
                return HttpNotFound();
            }
            return View(periodtime);
        }

        //
        // POST: /PeriodTime/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeriodTime periodtime = db.periodTime.Find(id);
            db.periodTime.Remove(periodtime);
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