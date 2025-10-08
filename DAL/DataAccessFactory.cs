using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Agent, int, Agent> AgentData()
        {
            return new AgentRepo();
        }
        public static IRepo<Budget, int, Budget> BudgetData()
        {
            return new BudgetRepo();
        }
        public static IRepo<Notification, int, Notification> NotificationData()
        {
            return new NotificationRepo();
        }
        public static IRepo<Transaction, int, Transaction> TransactionData()
        {
            return new TransactionRepo();
        }
        public static IRepo<Wallet, int, Wallet> WalletData()
        {
            return new WalletRepo();
        }
        public static IaddAndDed<Wallet, int, Wallet> WalletData2()
        {
            return new WalletRepo(); 
        }
        public static ISendMoney<User, string, User> UserSendMoney()
        {
            return new UserRepo();
        }

    }
}
