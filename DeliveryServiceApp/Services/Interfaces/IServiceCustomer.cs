using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceCustomer : IService<Customer>
    {
        public void Add(Customer customer);
        public void Delete(Customer customer);
        public void Edit(Customer customer);
    }
}
