using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static Object Get()
        {
            return UserRepo.Get();
        }
        public static User Get(int id)
        {
            return UserRepo.Get(id);
        }
        public static bool Create(User obj)
        {
            return UserRepo.Create(obj);
        }
        public static bool Update(User obj)
        {
            return UserRepo.Update(obj);
        }
        public static bool Delete(int id)
        {
            return UserRepo.Delete(id);
        }
        
        public static List<User> Get10()
        {
            var data = from u in UserRepo.Get()
                       where u.Id <= 10
                       select u;
            return data.ToList();
        }
    }
}
