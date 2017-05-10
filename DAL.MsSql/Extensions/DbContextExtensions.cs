using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.MsSql.Extensions
{
    public static class DbContextExtensions
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            // get the list of applied migrations from database
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(selector: m => m.MigrationId);

            // get the list of all the migrations in our code
            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(selector: m => m.Key);

            // check that all the migrations are applied
            // ie get the difference of two lists, check if there are any elements in result
            return !total.Except(second: applied).Any();
        }
    }
}