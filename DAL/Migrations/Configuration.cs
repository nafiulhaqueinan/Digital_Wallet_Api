namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.WalletDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.WalletDbContext context)
        {
            // -----------------------
            // Users
            // -----------------------
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(u => u.Email,
                    new User { Name = "User1", Email = "user1@example.com", Password = "pass123", Phone = "01711111111", Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new User { Name = "User2", Email = "user2@example.com", Password = "pass123", Phone = "01722222222", Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new User { Name = "User3", Email = "user3@example.com", Password = "pass123", Phone = "01733333333", Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new User { Name = "User4", Email = "user4@example.com", Password = "pass123", Phone = "01744444444", Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                );
            }

            // -----------------------
            // Agents
            // -----------------------
            if (!context.Agents.Any())
            {
                context.Agents.AddOrUpdate(a => a.Email,
                    new Agent { Name = "Agent1", Email = "agent1@example.com", Password = "agentpass", Phone = "01811111111", BusinessName = "Store1", CommissionRate = 2.5m, Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Agent { Name = "Agent2", Email = "agent2@example.com", Password = "agentpass", Phone = "01822222222", BusinessName = "Store2", CommissionRate = 3m, Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Agent { Name = "Agent3", Email = "agent3@example.com", Password = "agentpass", Phone = "01833333333", BusinessName = "Store3", CommissionRate = 2m, Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Agent { Name = "Agent4", Email = "agent4@example.com", Password = "agentpass", Phone = "01844444444", BusinessName = "Store4", CommissionRate = 2.8m, Status = "active", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                );
            }

            context.SaveChanges();

            // -----------------------
            // Wallets
            // -----------------------
            if (!context.Wallets.Any())
            {
                var users = context.Users.ToList();
                var agents = context.Agents.ToList();

                // Users wallets
                foreach (var user in users)
                {
                    context.Wallets.AddOrUpdate(w => w.UserId,
                        new Wallet { UserId = user.Id, Balance = 1000, Currency = "BDT", LastUpdate = DateTime.Now }
                    );
                }

                // Agents wallets
                foreach (var agent in agents)
                {
                    context.Wallets.AddOrUpdate(w => w.AgentId,
                        new Wallet { AgentId = agent.Id, Balance = 5000, Currency = "BDT", LastUpdate = DateTime.Now }
                    );
                }
            }

            context.SaveChanges();

            // -----------------------
            // Transactions
            // -----------------------
            if (!context.Transactions.Any())
            {
                var wallets = context.Wallets.ToList();
                var userWallets = wallets.Where(w => w.UserId != null).ToList();
                var agentWallets = wallets.Where(w => w.AgentId != null).ToList();

                if (userWallets.Count >= 4 && agentWallets.Count >= 3)
                {
                    context.Transactions.AddOrUpdate(t => t.Id,
                        new Transaction { SenderWalletId = userWallets[0].Id, ReceiverWalletId = userWallets[1].Id, Type = "transfer", Amount = 200, Status = "completed", CreatedAt = DateTime.Now },
                        new Transaction { SenderWalletId = userWallets[1].Id, ReceiverWalletId = userWallets[2].Id, Type = "transfer", Amount = 150, Status = "completed", CreatedAt = DateTime.Now },
                        new Transaction { SenderWalletId = userWallets[2].Id, ReceiverWalletId = userWallets[3].Id, Type = "transfer", Amount = 300, Status = "completed", CreatedAt = DateTime.Now },

                        new Transaction { SenderWalletId = agentWallets[0].Id, ReceiverWalletId = userWallets[0].Id, Type = "deposit", Amount = 500, Status = "completed", CreatedAt = DateTime.Now },
                        new Transaction { SenderWalletId = agentWallets[1].Id, ReceiverWalletId = userWallets[1].Id, Type = "deposit", Amount = 700, Status = "completed", CreatedAt = DateTime.Now },

                        new Transaction { SenderWalletId = userWallets[3].Id, ReceiverWalletId = agentWallets[2].Id, Type = "withdraw", Amount = 400, Status = "completed", CreatedAt = DateTime.Now }
                    );
                }
            }


            context.SaveChanges();

            // -----------------------
            // Budgets (for all users)
            // -----------------------
            if (!context.Budgets.Any())   
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    context.Budgets.AddOrUpdate(b => b.UserId,
                        new Budget
                        {
                            UserId = user.Id,
                            MonthlyLimit = 5000,
                            CurrentSpend = 0,
                            Month = DateTime.Now.ToString("yyyy-MM"),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        }
                    );
                }
            }

            context.SaveChanges();

            // -----------------------
            // Notifications
            // -----------------------
            // -----------------------
            // Notifications
            // -----------------------
            if (!context.Notifications.Any())
            {
                var users = context.Users.ToList();
                var agents = context.Agents.ToList();

                // Only create notifications for pairs that exist
                var notifications = new List<Notification>();

                for (int i = 0; i < users.Count && i < agents.Count; i++)
                {
                    notifications.Add(new Notification
                    {
                        UserId = users[i].Id,
                        AgentId = agents[i].Id,
                        Message = $"Welcome {users[i].Name}!",
                        Type = "system",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    });
                }

                context.Notifications.AddOrUpdate(n => n.Id, notifications.ToArray());
            }

            context.SaveChanges(); 
        }
    }
}
