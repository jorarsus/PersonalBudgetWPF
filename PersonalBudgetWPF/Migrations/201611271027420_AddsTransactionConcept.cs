namespace PersonalBudgetWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsTransactionConcept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Concept", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Concept");
        }
    }
}
