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

        public Person FindByID(int id, params int[] ids)
        {
            try
            {
                return context.Persons.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading person! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
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
                throw new Exception($"Error loading all persons! {Environment.NewLine}" +
                                    $"System Error: {ex.Message}");
            }
        }
    }
}
