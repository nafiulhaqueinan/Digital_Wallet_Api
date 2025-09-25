using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BudgetRepo : Repo, IRepo<Budget, string, Budget>
    {

        //static WalletDbContext db;
        //static BudgetRepo()
        //{
        //    db = new WalletDbContext();
        //}
        //public static List<Budget> Get()
        //{
        //    return db.Budgets.ToList();
        //}
        //public static Budget Get(int id)
        //{
        //    return db.Budgets.Find(id);
        //}
        //public static bool Create(Budget obj)
        //{
        //    db.Budgets.Add(obj);
        //    return db.SaveChanges() > 0;
        //}
        //public static bool Update(Budget obj)
        //{
        //    var ex = db.Budgets.Find(obj.Id);
        //    db.Entry(ex).CurrentValues.SetValues(obj);
        //    return db.SaveChanges() > 0;

        //}
        //static public bool Delete(int id)
        //{
        //    var ex = db.Budgets.Find(id);
        //    db.Budgets.Remove(ex);
        //    return db.SaveChanges() > 0;
        //}
        public Budget Create(Budget obj)
        {
            db.Budgets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }


        public Budget Delete(string id)
        {
            var ex = db.Budgets.Find(id);
            db.Budgets.Remove(ex);
            if (db.SaveChanges() > 0) return ex;
            else return null;

        }

        public List<Budget> Read()
        {
            return db.Budgets.ToList();
        }

        public Budget Read(string id)
        {
            return db.Budgets.Find(id);

        }

        public Budget Update(Budget obj)
        {
            var ex = db.Budgets.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;

        }
    }
}
