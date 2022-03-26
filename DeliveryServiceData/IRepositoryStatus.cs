using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryStatus : IRepository<Status>
    {
        public void Edit(Status status);
        public Status GetByName(string name);
    }
}
