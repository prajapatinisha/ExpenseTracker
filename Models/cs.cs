using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project1.Models
{
    public class cs : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ExpenseLimit> ExpenseLimits { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}