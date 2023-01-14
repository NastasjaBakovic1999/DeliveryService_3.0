using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryStatus : GenericRepository<Status>, IRepositoryStatus
    {
        public RepositoryStatus(DbContext context) : base(context)
        {

        }
    }
}
