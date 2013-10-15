using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlaner.DomainModel
{
    public interface IAddressRepository
    {
        IQueryable<Address> All();
        Address GetById(int id);

        void AddAddress(Address address);

        void ChangeAddress(Address address);
        void RemoveAddress(int id);
    }
}
