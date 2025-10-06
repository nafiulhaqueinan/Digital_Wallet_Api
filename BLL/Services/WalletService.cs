using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WalletService
    {
        public static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Wallet, WalletDTO>().ReverseMap();
            });
            return new Mapper(cfg);

        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.WalletData().Delete(id);
            return data != null;
        }
        public static bool Create(WalletDTO wallet)
        {
            var mapper = GetMapper();
            var mappedWallet = mapper.Map<DAL.Models.Wallet>(wallet);
            var createdWallet = DataAccessFactory.WalletData().Create(mappedWallet);
            return createdWallet != null;
        }
        public static List<WalletDTO> Get()
        {
            var data = DataAccessFactory.WalletData().Read();
            return GetMapper().Map<List<WalletDTO>>(data);
        }
        public static WalletDTO Get(int id)
        {
            var data = DataAccessFactory.WalletData().Read(id);
            var mapped = GetMapper().Map<WalletDTO>(data);
            return mapped;
        }
        public static bool Update(WalletDTO wallet)
        {
            var mapper = GetMapper();
            var mappedWallet = mapper.Map<DAL.Models.Wallet>(wallet);
            var updatedWallet = DataAccessFactory.WalletData().Update(mappedWallet);
            return updatedWallet != null;
        }
        public static WalletDTO AddMoney(int id, decimal amount)
        {
            var updatedWallet = DataAccessFactory.WalletData2().AddMoney(id, amount);
            return GetMapper().Map<WalletDTO>(updatedWallet);
        }
        public static WalletDTO DeductMoney(int id, decimal amount)
        {
            var updatedWallet = DataAccessFactory.WalletData2().DeductMoney(id, amount);
            return GetMapper().Map<WalletDTO>(updatedWallet);
        }

    }
}
