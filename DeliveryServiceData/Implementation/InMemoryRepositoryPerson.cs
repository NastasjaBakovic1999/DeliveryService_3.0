using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Person FindOneByExpression(Expression<Func<Person, bool>> expression)
        {
            return people.SingleOrDefault(expression.Compile());
        }

        public List<Person> GetAll()
        {
            return people;
        }
    }
}
