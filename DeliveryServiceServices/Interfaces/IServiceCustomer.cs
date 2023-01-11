using DataTransferObjects;
using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceCustomer : IService<CustomerDto>
    {
        public void Edit(CustomerDto customer);
    }
}
