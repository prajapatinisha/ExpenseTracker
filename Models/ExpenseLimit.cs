using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class ExpenseLimit
    {
        [Key]
        public int ExpLimitId { get; set; }

        [Required(ErrorMessage = "TotalExpLimit is Required")]
        public int TotExpLimit { get; set; }

        public int ExpId { get; set; }
        public virtual Expense expense { get; set; }
    }
}