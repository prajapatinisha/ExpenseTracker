namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExpenseLimits
    {
        [Key]
        public int ExpLimitId { get; set; }

        public int TotExpLimit { get; set; }

        public int ExpId { get; set; }

        public virtual Expenses Expenses { get; set; }
    }
}
