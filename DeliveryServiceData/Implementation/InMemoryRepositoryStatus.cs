using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    internal class InMemoryRepositoryStatus : IRepositoryStatus
    {
        private List<Status> statuses = new List<Status>();

        public InMemoryRepositoryStatus()
        {

        }

        public Status FindByID(int id, params int[] ids)
        {
            return statuses.Find(s => s.StatusId == id);
        }

        public List<Status> GetAll()
        {
            return statuses;
        }

        public Status GetByName(string name)
        {
            return statuses.Find(s => s.StatusName == name);
        }
    }
}
