using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly DeliveryServiceContext context;

        public RepositoryUser(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
        }

        public User FindByID(int id, params int[] ids)
        {
            return context.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Edit(User user)
        {
            context.Users.Update(user);
        }

        public User GetByUsernameAndPassword(User user)
        {
            return context.Users.Single(u => u.Username == user.Username && u.Password == user.Password);
        }

        public User Search(Expression<Func<User, bool>> pred)
        {
            return context.Users.SingleOrDefault(pred);
        }
        public List<User> SearchUsers(Expression<Func<User, bool>> pred)
        {
            return context.Users.Where(pred).ToList();
        }
    }
}