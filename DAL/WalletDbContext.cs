using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class WalletDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
