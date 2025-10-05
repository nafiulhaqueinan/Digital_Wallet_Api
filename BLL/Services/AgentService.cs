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
    public class AgentService
    {
        public static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Agent, AgentDTO>().ReverseMap();
            });
            return new Mapper(cfg);

        }
        public static bool Create(AgentDTO agent)
        {
            var mapper = GetMapper();
            var mappedAgent = mapper.Map<DAL.Models.Agent>(agent);
            var createdAgent = DataAccessFactory.AgentData().Create(mappedAgent);
            return createdAgent != null;
        }
        public static List<AgentDTO> Get()
        {
            var data = DataAccessFactory.AgentData().Read();
            return GetMapper().Map<List<AgentDTO>>(data);
        }
        public static AgentDTO Get(int id)
        {
            var data = DataAccessFactory.AgentData().Read(id);
            var mapped = GetMapper().Map<AgentDTO>(data);
            return mapped;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.AgentData().Delete(id);
            return data != null;
        }
        public static bool Update(AgentDTO agent)
        {
            var mapper = GetMapper();
            var mappedAgent = mapper.Map<DAL.Models.Agent>(agent);
            var updatedAgent = DataAccessFactory.AgentData().Update(mappedAgent);
            return updatedAgent != null;
        }

    }
}
