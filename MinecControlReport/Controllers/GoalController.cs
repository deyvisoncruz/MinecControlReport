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
    public class GoalController : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();

        //
        // GET: /Goal/

        public ActionResult Index()
        {
            var goal = db.goal.Include(g => g.kpi);
            return View(goal.ToList());
        }

        //
        // GET: /Goal/Details/5

        public ActionResult Details(int id = 0)
        {
            goal goal = db.goal.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        //
        // GET: /Goal/Create

        public ActionResult Create()
        {
            ViewBag.KpiId = new SelectList(db.kpis, "KpiId", "KpiName");
            return View();
        }

        //
        // POST: /Goal/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(goal goal)
        {
            if (ModelState.IsValid)
            {
                db.goal.Add(goal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KpiId = new SelectList(db.kpis, "KpiId", "KpiName", goal.KpiId);
            return View(goal);
        }

        //
        // GET: /Goal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            goal goal = db.goal.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            ViewBag.KpiId = new SelectList(db.kpis, "KpiId", "KpiName", goal.KpiId);
            return View(goal);
        }

        //
        // POST: /Goal/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(goal goal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KpiId = new SelectList(db.kpis, "KpiId", "KpiName", goal.KpiId);
            return View(goal);
        }

        //
        // GET: /Goal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            goal goal = db.goal.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        //
        // POST: /Goal/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            goal goal = db.goal.Find(id);
            db.goal.Remove(goal);
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