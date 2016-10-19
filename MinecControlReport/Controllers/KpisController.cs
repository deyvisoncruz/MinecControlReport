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
    public class KpisController : Controller
    {
        private MineControlReportContext db = new MineControlReportContext();

        //
        // GET: /Kpis/

        public ActionResult Index()
        {
            ViewBag.Message = "Customize seus índices";
            return View(db.kpis.ToList());
        }

        //
        // GET: /Kpis/Details/5

        public ActionResult Details(int id = 0)
        {

            ViewBag.Message = "Detalhes do Kpi";
            kpis kpis = db.kpis.Find(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // GET: /Kpis/Create

        public ActionResult Create()
        {
            ViewBag.Message = "Cadastre seus Kpis";
            return View();
        }

        //
        // POST: /Kpis/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kpis kpis)
        {
            if (ModelState.IsValid)
            {
                db.kpis.Add(kpis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kpis);
        }

        //
        // GET: /Kpis/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Message = "Editar Kpi";
            kpis kpis = db.kpis.Find(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // POST: /Kpis/Edit/5

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
        // GET: /Kpis/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ViewBag.Message = "Remover Kpis";
            kpis kpis = db.kpis.Find(id);
            if (kpis == null)
            {
                return HttpNotFound();
            }
            return View(kpis);
        }

        //
        // POST: /Kpis/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kpis kpis = db.kpis.Find(id);
            db.kpis.Remove(kpis);
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