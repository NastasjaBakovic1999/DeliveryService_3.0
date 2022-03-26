using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryStatus : IRepositoryStatus
    {
        private readonly DeliveryServiceContext context;

        public RepositoryStatus(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(Status status)
        {
            context.Statuses.Add(status);
        }

        public void Delete(Status status)
        {
            context.Statuses.Remove(status);
        }

        public Status FindByID(int id, params int[] ids)
        {
            return context.Statuses.Find(id);
        }

        public List<Status> GetAll()
        {
            return context.Statuses.ToList();
        }

        public void Edit(Status status)
        {
            context.Statuses.Update(status);
        }

        public Status GetByName(string name)
        {
            return context.Statuses.FirstOrDefault(s => s.StatusName == name);
        }
    }
}
