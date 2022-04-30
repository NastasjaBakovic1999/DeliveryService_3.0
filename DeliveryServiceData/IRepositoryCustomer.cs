using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryCustomer:IRepository<Customer>
    {
        public void Add(Customer customer);
        public void Delete(Customer customer);
        public void Edit(Customer customer);
    }
}
