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

        public bool InsertUser(User user)
        {
            if (context.Users.Any(x => x.UserName == user.UserName))
            {
                return false;
            }
            else
            {
                context.Users.Add(user);
                return true;
            }

        }

        public int login(User user)
        {
            User obj = context.Users.Where(a => a.UserName.Equals(user.UserName) &&
            a.Password.Equals(user.Password)).FirstOrDefault();
            if (obj != null)
            {
                if (obj.Active == true)
                    return obj.ID;
                else
                    return -1;
            }
            return -1;
        }

        public void DeleteUser(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);

        }

        public bool UpdateUser(User user)
        {
            if (context.Users.Any(x => x.UserName == user.UserName))
            {
                return false;
            }
            else
            {
                context.Entry(user).State = EntityState.Modified;
                return true;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
