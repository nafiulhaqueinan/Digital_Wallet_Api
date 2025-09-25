using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WalletRepo : Repo, IRepo<Wallet, string, Wallet>
    {

        //static WalletDbContext db;
        //static WalletRepo()
        //{
        //    db = new WalletDbContext();
        //}
        //public static List<Wallet> Get()
        //{
        //    return db.Wallets.ToList();
        //}
        //public static Wallet Get(int id)
        //{
        //    return db.Wallets.Find(id);
        //}
        //public static bool Create(Wallet obj)
        //{
        //    db.Wallets.Add(obj);
        //    return db.SaveChanges() > 0;
        //}
        //public static bool Update(Wallet obj)
        //{
        //    var ex = db.Wallets.Find(obj.Id);
        //    db.Entry(ex).CurrentValues.SetValues(obj);
        //    return db.SaveChanges() > 0;

        //}
        //static public bool Delete(int id)
        //{
        //    var ex = db.Wallets.Find(id);
        //    db.Wallets.Remove(ex);
        //    return db.SaveChanges() > 0;
        //}
        public Wallet Create(Wallet obj)
        {
            db.Wallets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }


        public Wallet Delete(string id)
        {
            var ex = db.Wallets.Find(id);
            db.Wallets.Remove(ex);
            if (db.SaveChanges() > 0) return ex;
            else return null;

        }

        public List<Wallet> Read()
        {
            return db.Wallets.ToList();
        }

        public Wallet Read(string id)
        {
            return db.Wallets.Find(id);

        }

        public Wallet Update(Wallet obj)
        {
            var ex = db.Wallets.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;

        }
    }
}
