using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationPlaner.DAL.EF;
using VacationPlaner.DomainModel;
using VacationPlaner.Web.Models.VacationPlaner;

namespace VacationPlaner.Web.Controllers
{
    public class VacationController : Controller
    {
        private VacationPlanerDbContext db = new VacationPlanerDbContext();

        //
        // GET: /Vacation/

        public ActionResult Index()
        {
            return View(db.Vacations.ToList());
        }

        //
        // GET: /Vacation/Details/5

        public ActionResult Details(int id = 0)
        {
            Vacation vacation = db.Vacations.Include("Address").FirstOrDefault(v => v.Id == id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        //
        // GET: /Vacation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vacation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                db.Vacations.Add(vacation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacation);
        }

        //
        // GET: /Vacation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vacation vacation = db.Vacations.Include("Address").FirstOrDefault(v => v.Id == id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        //
        // POST: /Vacation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacation).State = EntityState.Modified;
                db.SaveChanges();
                //db.Entry(vacation.Address).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacation);
        }

        //
        // GET: /Vacation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vacation vacation = db.Vacations.Find(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        //
        // POST: /Vacation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacation vacation = db.Vacations.Find(id);
            db.Vacations.Remove(vacation);
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