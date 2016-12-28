namespace PersonalBudgetWPF.Migrations
{
    using EF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalBudgetWPF.EF.PersonalBudgetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PersonalBudgetWPF.EF.PersonalBudgetEntities";
        }

        protected override void Seed(PersonalBudgetWPF.EF.PersonalBudgetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Accounts.AddOrUpdate(
                p => p.Concept,
                new Account { Concept = "Agua" },
                new Account { Concept = "Alquiler" },
                new Account { Concept = "Apoyo doméstico" },
                new Account { Concept = "Bolsillo" },
                new Account { Concept = "Caja" },
                new Account { Concept = "Formación" },
                new Account { Concept = "Cuenta corriente" },
                new Account { Concept = "Deudores" },
                new Account { Concept = "Informática" },
                new Account { Concept = "Electricidad" },
                new Account { Concept = "Hogar" },
                new Account { Concept = "Gas" },
                new Account { Concept = "Gasolina" },
                new Account { Concept = "Impuestos" },
                new Account { Concept = "Ingresos trabajo" },
                new Account { Concept = "Inversiones financieras" },
                new Account { Concept = "Libros/juegos" },
                new Account { Concept = "Mantenimiento casa" },
                new Account { Concept = "Mantenimiento coche" },
                new Account { Concept = "Médico/farmacia/personales" },
                new Account { Concept = "Alimentación" },
                new Account { Concept = "Otros" },
                new Account { Concept = "Otros transportes" },
                new Account { Concept = "Pendiente de asignar" },
                new Account { Concept = "Regalos/transferencias" },
                new Account { Concept = "Restaurante/cine/otros" },
                new Account { Concept = "Ropa" },
                new Account { Concept = "Internet" },
                new Account { Concept = "Teléfono" },
                new Account { Concept = "Viajes/vacaciones" }
            );
        }
    }
}
