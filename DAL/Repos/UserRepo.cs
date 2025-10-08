using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>, ISendMoney<User, string, User>
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
        public User GetByPhone(string phone)
        {
            return db.Users.Where(u => u.Phone == phone).FirstOrDefault();
        }

        public User SendMoney(User sender, string receiver, decimal amount)
        {
            var rcv = GetByPhone(receiver);
            if (rcv == null || sender == null) return null;
            var sndrWallet = db.Wallets.Where(w => w.UserId == sender.Id).FirstOrDefault();
            var rcvWallet = db.Wallets.Where(w => w.UserId == rcv.Id).FirstOrDefault();
            if (sndrWallet == null || rcvWallet == null) return null;
            if (sndrWallet.Balance < amount) return null;
            sndrWallet.Balance -= amount;
            rcvWallet.Balance += amount;
            db.Entry(sndrWallet).CurrentValues.SetValues(sndrWallet);
            db.Entry(rcvWallet).CurrentValues.SetValues(rcvWallet);
            if (db.SaveChanges() > 0) return rcv;
            else return null;
        }
    }
}
