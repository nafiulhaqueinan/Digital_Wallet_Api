using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>().ReverseMap();
            });
            return new Mapper(cfg);
            
        }
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            return GetMapper().Map<List<UserDTO>>(data);


        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var mapped = GetMapper().Map<UserDTO>(data);
            return mapped;
        }
        public static bool Create(UserDTO user)
        {
            var mapper = GetMapper();
            var mappedUser = mapper.Map<User>(user);
            var existingUser = DataAccessFactory.UserData()
                                .Read()
                                .FirstOrDefault(u => u.Phone == user.Phone);

            if (existingUser != null)
            {
                return false;
            }
            var createdUser = DataAccessFactory.UserData().Create(mappedUser);

            if (createdUser == null) return false;
            var wallet = new Wallet
            {
                UserId = createdUser.Id,
                Balance = 0,
                Currency = "BDT",
                LastUpdate = DateTime.Now,
                AgentId = 4
            };

            var walletRes = DataAccessFactory.WalletData().Create(wallet);
            var budget = new Budget
            {
                UserId = createdUser.Id,
                MonthlyLimit = 30000,
                CurrentSpend= 0,
                Month = DateTime.Now.ToString("yyyy-MM"),
                CreatedAt = DateTime.Now
            };
            var budgetRes = DataAccessFactory.BudgetData().Create(budget);


            return walletRes != null;
        }
        public static bool Update(UserDTO user)
        {
            var mapper = GetMapper();
            var mapped = mapper.Map<User>(user);
            var res = DataAccessFactory.UserData().Update(mapped);
            return res != null;

        }
        public static bool Delete(int  id)
        {
            var wallets = DataAccessFactory.WalletData().Read().Where(w => w.UserId == id).ToList();
            foreach(var wallet in wallets)
            {
                DataAccessFactory.WalletData().Delete(wallet.Id);
            }
            var data = DataAccessFactory.UserData().Delete(id);
            return data != null;
        }
        public static UserDTO GetbyPhone(string phone)
        {
            var data = DataAccessFactory.UserSendMoney().GetByPhone(phone);
            var mapped = GetMapper().Map<UserDTO>(data);
            return mapped;
        }

        public static bool SendMoney(int senderId, string rcvPhn, decimal amount)
        {

            var sender = DataAccessFactory.UserData().Read(senderId);
            if (sender == null) return false;
            var data = DataAccessFactory.UserSendMoney().SendMoney(sender, rcvPhn, amount);
            if (data == null) return false;
            var rcv = DataAccessFactory.UserData().Read().FirstOrDefault(u => u.Phone == rcvPhn);
            if (rcv == null) return false;
            var sndrWallet = DataAccessFactory.WalletData().Read().FirstOrDefault(w => w.UserId == sender.Id);
            var rcvWallet = DataAccessFactory.WalletData().Read().FirstOrDefault(w => w.UserId == rcv.Id);

            var sndrBudget = DataAccessFactory.BudgetData().Read().FirstOrDefault(b => b.UserId == sender.Id && b.Month == DateTime.Now.ToString("yyyy-MM"));
            if (sndrBudget.MonthlyLimit > sndrBudget.CurrentSpend)
            {
                sndrBudget.CurrentSpend += amount;
                DataAccessFactory.BudgetData().Update(sndrBudget);
            }
            else
            {
                return false;

            }


                var txn = new TransactionDTO
                {
                    SenderWalletId = sndrWallet.Id,
                    ReceiverWalletId = rcvWallet.Id,
                    Type = "SendMoney",
                    Amount = amount,
                    Status = "Success",
                    CreatedAt = DateTime.Now
                };
            var txnResult = TransactionService.Create(txn);

            var SndrMsg = $"You have sent {amount} to {rcv.Name}, New Balance: {sndrWallet.Balance}";
            var RcvMsg = $"You have received {amount} from {sender.Name}, New Balance: {rcvWallet.Balance}";

            NotificationService.Create(new NotificationDTO
            {
                UserId = sender.Id,
                Message = SndrMsg,
                Type = "Transaction",
                CreatedAt = DateTime.Now,
                IsRead = false
            });

            NotificationService.Create(new NotificationDTO
            {
                UserId = rcv.Id,
                Message = RcvMsg,
                Type = "Transaction",
                CreatedAt = DateTime.Now,
                IsRead = false
            });


            return txnResult;
        }
        public static bool ResetPassword(int userId, string oldPassword, string newPassword)
        {
            var user = DataAccessFactory.UserData().Read(userId);
            if (user == null || user.Password != oldPassword)
            {
                return false;
            }
            user.Password = newPassword;
            var updatedUser = DataAccessFactory.UserData().Update(user);
            return updatedUser != null;
        }
    }
}
