using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationPlaner.DAL.EF;
using VacationPlaner.DomainModel;
using VacationPlaner.Web.Models;

namespace VacationPlaner.Web.Controllers
{
    public class AddressController : Controller
    {

        private readonly IAddressRepository _repository;

        public AddressController() : this(new AddressRepository())
        {
            
        }

        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Address/

        public ActionResult Index()
        {
            // ViewData.ModelMetadata = new ModelMetadata();
            return View(_repository.All().ToList());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id = 0)
        {
            Address address = _repository.GetById(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _repository.AddAddress(address);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Address address = _repository.GetById(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                _repository.ChangeAddress(address);
                return RedirectToAction("Index");
            }
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Address address = _repository.GetById(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.RemoveAddress(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            var disposable = _repository as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}