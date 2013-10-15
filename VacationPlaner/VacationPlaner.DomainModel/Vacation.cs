using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlaner.DomainModel
{
    [MetadataType(typeof(VacationMetadata))]
    public class Vacation
    {
        public Vacation()
        {
            Persons = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string VacationName { get; set; }
        [UIHint("Address1", "MVC")]
        public Address Address { get; set; }

        public ICollection<Person> Persons { get; set; }

        public void AddParticipantToTheParty(Person person)
        {
            Persons.Add(person);
        }
    }

    public class VacationMetadata
    {
    }
}
