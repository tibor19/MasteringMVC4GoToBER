using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlaner.DomainModel;

namespace VacationPlaner.DAL.EF
{
    public class AddressRepository : IAddressRepository
    {
        private VacationPlanerDbContext db = new VacationPlanerDbContext();
        public IQueryable<Address> All()
        {
            return db.Addresses;
        }

        public Address GetById(int id)
        {
            return db.Addresses.Find(id);
        }

        public void AddAddress(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
        }

        public void ChangeAddress(Address address)
        {
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
        }
    }
}
