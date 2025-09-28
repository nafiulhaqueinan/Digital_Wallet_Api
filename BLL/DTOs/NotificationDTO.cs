using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int? AgentId { get; set; }

        public User User { get; set; }

        public Agent Agent { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Type { get; set; } // transaction, budget, system

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
