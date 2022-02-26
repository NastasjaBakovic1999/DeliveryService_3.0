using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryLocation : IRepositoryLocation
    {
        private readonly DeliveryServiceContext context;

        public RepositoryLocation(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(Location location)
        {
            context.Locations.Add(location);
        }

        public void Delete(Location location)
        {
            context.Locations.Remove(location);
        }

        public Location FindByID(int id, params int[] ids)
        {
            return context.Locations.Find(id);
        }

        public List<Location> GetAll()
        {
            return context.Locations.ToList();
        }

        public List<Location> Search(Expression<Func<Location, bool>> pred)
        {
            return context.Locations.Where(pred).ToList();
        }
    }
}
