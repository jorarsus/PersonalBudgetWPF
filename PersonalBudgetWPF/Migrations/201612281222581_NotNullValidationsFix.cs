namespace PersonalBudgetWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNullValidationsFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transactions", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Value", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "Date", c => c.DateTime());
        }
    }
}
