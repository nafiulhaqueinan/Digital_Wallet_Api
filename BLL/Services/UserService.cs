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
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;


        }

        public static UserDTO Get(string id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }
        public static bool Create(UserDTO user)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mappedUser = mapper.Map<User>(user);

            // Check if phone number already exists
            var existingUser = DataAccessFactory.UserData()
                                .Read()
                                .FirstOrDefault(u => u.Phone == user.Phone);

            if (existingUser != null)
            {
                // Phone Number already Used
                return false;
            }

            // ✅ Save user first
            var createdUser = DataAccessFactory.UserData().Create(mappedUser);

            if (createdUser == null) return false;

            // ✅ Now create wallet with correct UserId
            var wallet = new Wallet
            {
                UserId = createdUser.Id,   // <-- now we have real DB Id
                Balance = 10000,
                Currency = "BDT",
                LastUpdate = DateTime.Now,
                AgentId = 1
            };

            var walletRes = DataAccessFactory.WalletData().Create(wallet);

            return walletRes != null;
        }

    }
}
