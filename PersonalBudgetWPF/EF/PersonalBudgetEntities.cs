namespace PersonalBudgetWPF.EF
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class PersonalBudgetContext : DbContext
    {
        // Your context has been configured to use a 'PersonalBudgetEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PersonalBudgetWPF.EF.PersonalBudgetEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PersonalBudgetEntities' 
        // connection string in the application configuration file.
        public PersonalBudgetContext()
            : base("name=PersonalBudgetEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Type> Types { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Value { get; set; }

        public Nullable<int> AccountID { get; set; } // Foreign Key
        public Account Account { get; set; }

        public Nullable<int> TypeID { get; set; } // Foreign Key
        public Type Type { get; set; }

    }

    public class Account
    {
        public int Id { get; set; }
        public String Concept;

        public virtual ICollection<Transaction> Transactions { get; set; }
    }

    public class Type
    {
        public int Id { get; set; }
        public String Description { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}