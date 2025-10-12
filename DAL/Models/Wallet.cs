using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int? AgentId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }

        public decimal Balance { get; set; } = 0;
        public string Currency { get; set; } = "BDT";

        public DateTime LastUpdate { get; set; } = DateTime.Now;

        
        public ICollection<Transaction> SentTransactions { get; set; }
        public ICollection<Transaction> ReceivedTransactions { get; set; }
    }
}
