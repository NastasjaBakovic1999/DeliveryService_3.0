using DeliveryServiceData.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.UnitOfWork.Implementation
{
    public class InMemoryPersonUnitOfWork : IPersonUnitOfWork
    {
        public InMemoryPersonUnitOfWork()
        {

        }

        public IRepositoryCustomer Customer { get; set; } = new InMemoryRepositoryCustomer();
        public IRepositoryDeliverer Deliverer { get; set; } = new InMemoryRepositoryDeliverer();
        public IRepositoryPerson Person { get; set; } = new InMemoryRepositoryPerson();

        public void Commit()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
