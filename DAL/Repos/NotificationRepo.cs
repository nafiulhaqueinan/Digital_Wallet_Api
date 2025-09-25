using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo : Repo, IRepo<Notification, string, Notification>
    {

        //static WalletDbContext db;
        //static NotificationRepo()
        //{
        //    db = new WalletDbContext();
        //}
        //public static List<Notification> Get()
        //{
        //    return db.Notifications.ToList();
        //}
        //public static Notification Get(int id)
        //{
        //    return db.Notifications.Find(id);
        //}
        //public static bool Create(Notification obj)
        //{
        //    db.Notifications.Add(obj);
        //    return db.SaveChanges() > 0;
        //}
        //public static bool Update(Notification obj)
        //{
        //    var ex = db.Notifications.Find(obj.Id);
        //    db.Entry(ex).CurrentValues.SetValues(obj);
        //    return db.SaveChanges() > 0;

        //}
        //static public bool Delete(int id)
        //{
        //    var ex = db.Notifications.Find(id);
        //    db.Notifications.Remove(ex);
        //    return db.SaveChanges() > 0;
        //}
        public Notification Create(Notification obj)
        {
            db.Notifications.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }


        public Notification Delete(string id)
        {
            var ex = db.Notifications.Find(id);
            db.Notifications.Remove(ex);
            if (db.SaveChanges() > 0) return ex;
            else return null;

        }

        public List<Notification> Read()
        {
            return db.Notifications.ToList();
        }

        public Notification Read(string id)
        {
            return db.Notifications.Find(id);

        }

        public Notification Update(Notification obj)
        {
            var ex = db.Notifications.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;

        }
    }
}
