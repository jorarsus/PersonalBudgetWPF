namespace PersonalBudgetWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsAccountAndType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "AccountID", c => c.Int());
            AddColumn("dbo.Transactions", "TypeID", c => c.Int());
            CreateIndex("dbo.Transactions", "AccountID");
            CreateIndex("dbo.Transactions", "TypeID");
            AddForeignKey("dbo.Transactions", "AccountID", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Transactions", "TypeID", "dbo.Types", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Transactions", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "TypeID" });
            DropIndex("dbo.Transactions", new[] { "AccountID" });
            DropColumn("dbo.Transactions", "TypeID");
            DropColumn("dbo.Transactions", "AccountID");
            DropTable("dbo.Types");
            DropTable("dbo.Accounts");
        }
    }
}
