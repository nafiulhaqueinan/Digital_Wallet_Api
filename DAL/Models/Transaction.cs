using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SenderWalletId { get; set; }

        [Required]
        public int ReceiverWalletId { get; set; }

        [ForeignKey("SenderWalletId")]
        public virtual Wallet SenderWallet { get; set; }

        [ForeignKey("ReceiverWalletId")]
        public virtual Wallet ReceiverWallet { get; set; }

        [Required]
        public string Type { get; set; } 

        [Required]
        public decimal Amount { get; set; }

        public string Status { get; set; } = "pending"; 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
