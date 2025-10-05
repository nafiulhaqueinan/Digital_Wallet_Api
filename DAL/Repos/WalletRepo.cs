using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WalletRepo : Repo, IRepo<Wallet, int, Wallet>, IaddAndDed<Wallet, int, Wallet>
    {
      

        public Wallet Create(Wallet obj)
        {
            db.Wallets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }


        public Wallet Delete(int id)
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

        public Wallet Read(int id)
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

        public Wallet AddMoney(int id, decimal amount)
        {
            var wallet = db.Wallets.Find(id);
            if (wallet != null)
            {
                wallet.Balance += amount;
                if (db.SaveChanges() > 0) return wallet;
            }
            return null;
        }
        public Wallet DeductMoney(int id, decimal amount)
        {
            var wallet = db.Wallets.Find(id);
            if (wallet != null && wallet.Balance >= amount)
            {
                wallet.Balance -= amount;
                if (db.SaveChanges() > 0) return wallet;
            }
            return null;
        }
    }
}
