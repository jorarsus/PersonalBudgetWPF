namespace PersonalBudgetWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNullValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Concept", c => c.String(nullable: false));
            AlterColumn("dbo.Transactions", "Date", c => c.DateTime());
            AlterColumn("dbo.Transactions", "Value", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "Concept", c => c.String(nullable: false));
            AlterColumn("dbo.Types", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Types", "Description", c => c.String());
            AlterColumn("dbo.Transactions", "Concept", c => c.String());
            AlterColumn("dbo.Transactions", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "Concept", c => c.String());
        }
    }
}
