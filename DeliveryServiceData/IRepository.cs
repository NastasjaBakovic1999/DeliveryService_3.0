using System;
using System.Collections.Generic;

namespace DeliveryServiceData
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T FindByID(int id, params int[] ids);
    }
}
