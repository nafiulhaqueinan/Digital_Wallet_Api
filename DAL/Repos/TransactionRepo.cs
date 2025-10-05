using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TransactionRepo : Repo, IRepo<Transaction, int, Transaction>
    {

        public Transaction Create(Transaction obj)
        {
            db.Transactions.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }


        public Transaction Delete(int id)
        {
            var ex = db.Transactions.Find(id);
            db.Transactions.Remove(ex);
            if (db.SaveChanges() > 0) return ex;
            else return null;

        }

        public List<Transaction> Read()
        {
            return db.Transactions.ToList();
        }

        public Transaction Read(int id)
        {
            return db.Transactions.Find(id);

        }

        public Transaction Update(Transaction obj)
        {
            var ex = db.Transactions.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;

        }
    }
}
