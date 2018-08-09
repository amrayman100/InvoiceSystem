using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.DAL;
using System.Data.Entity;

namespace Collection.Repository
{
    public class UserRepo
    {
        private invoicesystemEntities context;
        public UserRepo()
        {
            context = new invoicesystemEntities();
        }
        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }
        public User GetUserByID(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);

        }

        public void DeleteUser(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);

        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;

        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
