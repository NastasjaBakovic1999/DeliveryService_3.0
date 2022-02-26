using System;
using System.Collections.Generic;

namespace DeliveryServiceData
{
    public interface IRepository<T>
    {
        void Add(T param);
        List<T> GetAll();
        T FindByID(int id, params int[] ids);
        void Delete(T param);
    }
}
