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
            var st = GetMapper().Map<UserDTO>(id);
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
                AgentId = 1
            };

            var walletRes = DataAccessFactory.WalletData().Create(wallet);

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


    }
}
