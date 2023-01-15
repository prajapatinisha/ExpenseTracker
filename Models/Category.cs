using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Project1.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(40, ErrorMessage = "Cannot accept more than 40 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CatExpLimit is Required")]
        public int CatExpLimit { get; set; }

        public int ExpId { get; set; }
        public virtual Expense expense { get; set; }
    }
}