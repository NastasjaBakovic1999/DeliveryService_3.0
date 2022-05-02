using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryPerson : IRepositoryPerson
    {
        private List<Person> people = new List<Person>();

        public InMemoryRepositoryPerson()
        {

        }

        public Person FindByID(int id, params int[] ids)
        {
            return people.Find(p => p.Id == id);
        }

        public List<Person> GetAll()
        {
            return people;
        }
    }
}
