using DeliveryServiceDomain;

namespace DeliveryServiceApp.Services.Interfaces
{
    public interface IServicePerson : IService<Person>
    {
        public void Add(Person person);
        public void Delete(Person person);
    }
}
