﻿namespace Project1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project1.Models.cs>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Project1.Models.cs";
        }

        protected override void Seed(Project1.Models.cs context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
