using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class WalletDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int? AgentId { get; set; }

        public User User { get; set; }

        public Agent Agent { get; set; }

        public decimal Balance { get; set; } = 0;
        public string Currency { get; set; } = "BDT";

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
