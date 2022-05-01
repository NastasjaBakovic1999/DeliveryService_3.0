using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceStatus : IService<Status>
    {
        public Status GetByName(string name);
    }
}
