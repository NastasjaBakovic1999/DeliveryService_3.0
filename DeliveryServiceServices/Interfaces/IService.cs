using System.Collections.Generic;

namespace DeliveryServiceApp.Services
{
    public interface IService<T> where T : class
    {
        List<T> GetAll();
        T FindByID(int id, params int[] ids);
    }
}
