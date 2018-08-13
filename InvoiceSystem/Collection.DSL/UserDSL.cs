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
            return repo.GetUserByID(id);
        }

        public bool InsertUser(User user)
        {
            var list = repo.GetUsers();
            int cnt = list.Count();
            foreach (var i in list)
            {
                if (i.User_No >= cnt)
                    cnt = (int)i.User_No + 1;
            }
            user.User_No = cnt;
            return (repo.InsertUser(user));
        }

        public void DeleteUser(int id)
        {
            repo.DeleteUser(id);
        }

        public bool UpdateUser(User user)
        {
            return(repo.UpdateUser(user));
        }

        public int userlogin(User user)
        {
            return (repo.login(user));
        }
        public void Commit()
        {
            repo.Commit();
        }
    }
}
