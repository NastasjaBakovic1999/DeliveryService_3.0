using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeliveryServiceData
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T FindOneByExpression(Expression<Func<T, bool>> expression);
    }
}
