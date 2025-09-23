using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo
    {
        static WalletDbContext db;
        static UserRepo()
        {
            db = new WalletDbContext();
        }
        public static List<Models.User> Get()
        {
            return db.Users.ToList();
        }
        public static Models.User Get(int id)
        {
            return db.Users.Find(id);
        }
        public static void Add(Models.User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
        }
        public static void Edit(Models.User obj)
        {
            var ex = db.Users.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
