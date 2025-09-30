namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWalletAndUserModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wallets", "UserId", "dbo.Users");
            DropIndex("dbo.Wallets", new[] { "UserId" });
            AlterColumn("dbo.Wallets", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Wallets", "UserId");
            AddForeignKey("dbo.Wallets", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "UserId", "dbo.Users");
            DropIndex("dbo.Wallets", new[] { "UserId" });
            AlterColumn("dbo.Wallets", "UserId", c => c.Int());
            CreateIndex("dbo.Wallets", "UserId");
            AddForeignKey("dbo.Wallets", "UserId", "dbo.Users", "Id");
        }
    }
}
