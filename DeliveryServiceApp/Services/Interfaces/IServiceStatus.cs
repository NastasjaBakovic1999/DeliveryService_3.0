using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceStatus : IService<Status>
    {
        public void Edit(Status status);
        public Status GetByName(string name);
    }
}
