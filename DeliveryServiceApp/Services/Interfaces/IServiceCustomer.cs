using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceCustomer : IService<Customer>
    {
        public void Edit(Customer customer);
    }
}
