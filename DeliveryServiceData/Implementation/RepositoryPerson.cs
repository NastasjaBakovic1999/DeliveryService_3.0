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
        private readonly DeliveryServiceContext context;

        public RepositoryPerson(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(Person person)
        {
            context.Persons.Add(person);
        }

        public void Delete(Person person)
        {
            context.Persons.Remove(person);
        }

        public Person FindByID(int id, params int[] ids)
        {
            return context.Persons.Find(id);
        }

        public List<Person> GetAll()
        {
            return context.Persons.ToList();
        }

        public Person GetPersonByUsernameAndPassword(Person person)
        {
            return context.Persons.Single(p => p.Username == person.Username && p.Password == person.Password);
        }

    }
}
