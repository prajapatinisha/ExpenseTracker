using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project1
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ExpenseLimits> ExpenseLimits { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
