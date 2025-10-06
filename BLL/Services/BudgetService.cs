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
    public class BudgetService
    {
        public static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Budget, BudgetDTO>().ReverseMap();
            });
            return new Mapper(cfg);

        }

        public static bool Create(BudgetDTO budget)
        {
            var mapper = GetMapper();
            var mappedBudget = mapper.Map<Budget>(budget);
            var createdBudget = DataAccessFactory.BudgetData().Create(mappedBudget);
            return createdBudget != null;
        }
        public static List<BudgetDTO> Get()
        {
            var data = DataAccessFactory.BudgetData().Read();
            return GetMapper().Map<List<BudgetDTO>>(data);
        }
        public static BudgetDTO Get(int id)
        {
            var data = DataAccessFactory.BudgetData().Read(id);
            var mapped = GetMapper().Map<BudgetDTO>(data);
            return mapped;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.BudgetData().Delete(id);
            return data != null;
        }
        public static bool Update(BudgetDTO budget)
        {
            var mapper = GetMapper();
            var mappedBudget = mapper.Map<Budget>(budget);
            var updatedBudget = DataAccessFactory.BudgetData().Update(mappedBudget);
            return updatedBudget != null;
        }

    }
}
