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

        public IRepositoryCustomer Customer { get; set; }
        public IRepositoryDeliverer Deliverer { get; set; }
        public IRepositoryPerson Person { get; set; }

        public void Commit()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
