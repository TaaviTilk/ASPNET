using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace DAL.MsSql.Extensions
{
    public static class ApplicationDbContextExtensions
    {
        public static void EnsureSeedData(this ApplicationDbContext context)
        {
            //check database migration status, is it latest? is it ok to seed?
            if (context.AllMigrationsApplied())
            {
                // TODO: seed some users and roles



                if (!context.People.Any())
                {
                    context.People.Add(entity: new Person() {FirstName = "Andres", LastName = "Käver"});
                    context.People.Add(entity: new Person() {FirstName = "Mait", LastName = "Poska"});
                    context.SaveChanges();
                }

            }
        }

    }
}
