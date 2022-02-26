using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryLocation : IRepository<Location>
    {
        public List<Location> Search(Expression<Func<Location, bool>> pred);
    }
}
