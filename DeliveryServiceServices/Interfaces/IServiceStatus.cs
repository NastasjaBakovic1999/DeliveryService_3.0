using DataTransferObjects;
using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceStatus : IService<StatusDto>
    {
        public StatusDto GetByName(string name);
    }
}
