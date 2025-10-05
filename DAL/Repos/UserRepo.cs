using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }


        public User Delete(int id)
        {
            var ex = db.Users.Find(id);
            if(ex == null) return null;
            db.Users.Remove(ex);
            if (db.SaveChanges() > 0) return ex;
            else return null;

        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int id)
        {
            return db.Users.Find(id);

        }

        public User Update(User obj)
        {
            var ex = db.Users.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;

        }
    }
}
