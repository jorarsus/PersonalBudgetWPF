namespace PersonalBudgetWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionConceptNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Concept", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Concept", c => c.String(nullable: false));
        }
    }
}
