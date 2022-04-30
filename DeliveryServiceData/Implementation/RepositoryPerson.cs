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
            try
            {
                context.Persons.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom čuvanja nove osobe! Greška: {ex.Message}");
            }
        }

        public void Delete(Person entity)
        {
            try
            {
                context.Persons.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom brisanja osobe! Greška: {ex.Message}");
            }
        }

        public Person FindByID(int id, params int[] ids)
        {
            try
            {
                return context.Persons.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja osobe! Greška: {ex.Message}");
            }
        }

        public List<Person> GetAll()
        {
            try
            {
                return context.Persons.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Greška prilikom učitavanja svih osoba! Greška: {ex.Message}");
            }
        }
    }
}
