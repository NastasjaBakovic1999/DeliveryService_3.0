using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServiceDeliverer : IService<Deliverer>
    {
        public void Add(Deliverer deliverer);
        public void Delete(Deliverer deliverer);
    }
}
