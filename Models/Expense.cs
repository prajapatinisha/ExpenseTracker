using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Project1.Models
{
    public class Expense
    {
        [Key]
        public int ExpId { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        [StringLength(40, ErrorMessage = "Cannot accept more than 40 characters")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Amount is Required")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }

    }
}