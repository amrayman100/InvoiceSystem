using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collection.DAL;

namespace Collection.DSL
{
    public class UserDSL
    {
        UserRepo repo = new UserRepo();
        
        public IEnumerable<User> GetUsers()
        {
            var list = repo.GetUsers();
            return list;
        }
        public User GetUserByID(int id)
        {
            return GetUserByID(id);
        }

        public void InsertUser(User user)
        {
            repo.InsertUser(user);

        }

        public void DeleteUser(int id)
        {
            repo.DeleteUser(id);
        }

        public void UpdateUser(User user)
        {
            repo.UpdateUser(user);
        }

        public void Commit()
        {
            repo.Commit();
        }
    }
}
