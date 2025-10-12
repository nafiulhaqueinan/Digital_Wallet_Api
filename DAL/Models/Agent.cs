using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string BusinessName { get; set; }

        public string LicenseNo { get; set; }

        public decimal CommissionRate { get; set; } = 0; 

        public string Location { get; set; }

        public string Status { get; set; } = "active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;



     
        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
