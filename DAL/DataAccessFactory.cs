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
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Agent, string, Agent> AgentData()
        {
            return new AgentRepo();
        }
        public static IRepo<Budget, string, Budget> BudgetData()
        {
            return new BudgetRepo();
        }
        public static IRepo<Notification, string, Notification> NotificationData()
        {
            return new NotificationRepo();
        }
        public static IRepo<Transaction, string, Transaction> TransactionData()
        {
            return new TransactionRepo();
        }
        public static IRepo<Wallet, string, Wallet> WalletData()
        {
            return new WalletRepo();
        }

    }
}
