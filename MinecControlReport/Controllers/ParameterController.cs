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
    public class ParameterController : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();

        //
        // GET: /Parameter/

        public ActionResult Index()
        {
            return View(db.parameter.ToList());
        }

        //
        // GET: /Parameter/Details/5

        public ActionResult Details(int id = 0)
        {
            Parameter parameter = db.parameter.Find(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // GET: /Parameter/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Parameter/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                db.parameter.Add(parameter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parameter);
        }

        //
        // GET: /Parameter/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Parameter parameter = db.parameter.Find(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // POST: /Parameter/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parameter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        //
        // GET: /Parameter/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Parameter parameter = db.parameter.Find(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // POST: /Parameter/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parameter parameter = db.parameter.Find(id);
            db.parameter.Remove(parameter);
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