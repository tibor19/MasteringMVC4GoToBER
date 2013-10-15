using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VacationPlaner.DAL.EF;
using VacationPlaner.DomainModel;
using VacationPlaner.Web.Models.VacationPlaner;

namespace VacationPlaner.Web.Controllers.Api
{
    public class AddressController : ApiController
    {
        private VacationPlanerDbContext db = new VacationPlanerDbContext();

        // GET api/Address
        public IEnumerable<Address> GetAddresses()
        {
            return db.Addresses.AsEnumerable();
        }

        // GET api/Address/5
        public Address GetAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return address;
        }

        // PUT api/Address/5
        public HttpResponseMessage PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != address.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Address
        public HttpResponseMessage PostAddress(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, address);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = address.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Address/5
        public HttpResponseMessage DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Addresses.Remove(address);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, address);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}