using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryAdditonalService : IRepositoryAdditionalService
    {
        private List<AdditionalService> additionalServices = new List<AdditionalService>();

        public AdditionalService FindOneByExpression(Expression<Func<AdditionalService, bool>> expression)
        {
            return additionalServices.SingleOrDefault(expression.Compile());
        }

        public List<AdditionalService> GetAll()
        {
            return additionalServices;
        }
    }
}