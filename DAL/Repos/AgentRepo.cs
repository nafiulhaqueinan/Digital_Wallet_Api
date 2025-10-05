using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AgentRepo : Repo, IRepo<Agent, int, Agent>
    {
        public Agent Create(Agent obj)
        {
            db.Agents.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }


        public Agent Delete(int id)
        {
            var ex = db.Agents.Find(id);
            db.Agents.Remove(ex);
            if (db.SaveChanges() > 0) return ex;
            else return null;

        }

        public List<Agent> Read()
        {
            return db.Agents.ToList();
        }

        public Agent Read(int id)
        {
            return db.Agents.Find(id);

        }

        public Agent Update(Agent obj)
        {
            var ex = db.Agents.Find(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;

        }
    }
}

