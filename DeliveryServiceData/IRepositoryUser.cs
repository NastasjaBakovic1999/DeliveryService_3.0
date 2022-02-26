using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData
{
    public interface IRepositoryUser : IRepository<User>
    {
        public void Edit(User user);
        public User GetByUsernameAndPassword(User user);
        public User Search(Expression<Func<User, bool>> pred);
        public List<User> SearchUsers(Expression<Func<User, bool>> pred);
    }
}
