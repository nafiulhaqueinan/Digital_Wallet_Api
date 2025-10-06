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
    public class TransactionService
    {
        public static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Transaction, TransactionDTO>().ReverseMap();
            });
            return new Mapper(cfg);

        }

        public static bool Create(TransactionDTO transaction)
        {
            var mapper = GetMapper();
            var mappedTransaction = mapper.Map<Transaction>(transaction);
            var createdTransaction = DataAccessFactory.TransactionData().Create(mappedTransaction);
            return createdTransaction != null;
        }
        public static List<TransactionDTO> Get()
        {
            var data = DataAccessFactory.TransactionData().Read();
            return GetMapper().Map<List<TransactionDTO>>(data);
        }
        public static TransactionDTO Get(int id)
        {
            var data = DataAccessFactory.TransactionData().Read(id);
            var mapped = GetMapper().Map<TransactionDTO>(data);
            return mapped;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.TransactionData().Delete(id);
            return data != null;
        }
        public static bool Update(TransactionDTO transaction)
        {
            var mapper = GetMapper();
            var mappedTransaction = mapper.Map<DAL.Models.Transaction>(transaction);
            var updatedTransaction = DataAccessFactory.TransactionData().Update(mappedTransaction);
            return updatedTransaction != null;
        }

    }
}
