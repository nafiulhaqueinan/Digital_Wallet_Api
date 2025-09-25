using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int? AgentId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Type { get; set; } // transaction, budget, system

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
