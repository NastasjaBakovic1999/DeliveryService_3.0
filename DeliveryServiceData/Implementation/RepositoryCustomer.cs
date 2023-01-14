using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryCustomer : GenericRepository<Customer>, IRepositoryCustomer
    {
        public RepositoryCustomer(DbContext context) : base(context)
        {
        }

        public void Edit(Customer customer)
        {
            Context.Set<Customer>().Update(customer);
        }
    }
}
