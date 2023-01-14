using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; }
        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        public virtual List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual T FindOneByExpression(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().SingleOrDefault(expression);
        }

    }
}
