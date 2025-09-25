namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTransactionIssue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 20),
                        BusinessName = c.String(maxLength: 150),
                        LicenseNo = c.String(),
                        CommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location = c.String(),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        AgentId = c.Int(),
                        Message = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MonthlyLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentSpend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Month = c.String(nullable: false, maxLength: 7),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderWalletId = c.Int(nullable: false),
                        ReceiverWalletId = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wallets", t => t.ReceiverWalletId)
                .ForeignKey("dbo.Wallets", t => t.SenderWalletId)
                .Index(t => t.SenderWalletId)
                .Index(t => t.ReceiverWalletId);
            
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Users", "Status", c => c.String(nullable: false));
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Wallets", "UserId", c => c.Int());
            AddColumn("dbo.Wallets", "AgentId", c => c.Int());
            AddColumn("dbo.Wallets", "Currency", c => c.String());
            AddColumn("dbo.Wallets", "LastUpdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Wallets", "UserId");
            CreateIndex("dbo.Wallets", "AgentId");
            AddForeignKey("dbo.Wallets", "AgentId", "dbo.Agents", "Id");
            AddForeignKey("dbo.Wallets", "UserId", "dbo.Users", "Id");
            DropColumn("dbo.Wallets", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wallets", "Name", c => c.String());
            DropForeignKey("dbo.Wallets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "SenderWalletId", "dbo.Wallets");
            DropForeignKey("dbo.Transactions", "ReceiverWalletId", "dbo.Wallets");
            DropForeignKey("dbo.Wallets", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.Budgets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "AgentId", "dbo.Agents");
            DropIndex("dbo.Transactions", new[] { "ReceiverWalletId" });
            DropIndex("dbo.Transactions", new[] { "SenderWalletId" });
            DropIndex("dbo.Wallets", new[] { "AgentId" });
            DropIndex("dbo.Wallets", new[] { "UserId" });
            DropIndex("dbo.Budgets", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "AgentId" });
            DropIndex("dbo.Notifications", new[] { "UserId" });
            AlterColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Wallets", "LastUpdate");
            DropColumn("dbo.Wallets", "Currency");
            DropColumn("dbo.Wallets", "AgentId");
            DropColumn("dbo.Wallets", "UserId");
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "CreatedAt");
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Email");
            DropTable("dbo.Transactions");
            DropTable("dbo.Budgets");
            DropTable("dbo.Notifications");
            DropTable("dbo.Agents");
        }
    }
}
