using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryPerson : IRepositoryPerson
    {
        private readonly PersonContext context;

        public RepositoryPerson(PersonContext context)
        {
            this.context = context;
        }

        public void Add(Person entity)
        {
            context.Persons.Add(entity);
        }

        public void Delete(Person entity)
        {
            context.Persons.Remove(entity);
        }

        public Person FindByID(int id, params int[] ids)
        {
            return context.Persons.Find(id);
        }

        public List<Person> GetAll()
        {
            return context.Persons.ToList();
        }
    }
}
