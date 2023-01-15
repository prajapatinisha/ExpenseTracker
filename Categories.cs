namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories
    {
        [Key]
        public int CatId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public int CatExpLimit { get; set; }

        public int ExpId { get; set; }

        public virtual Expenses Expenses { get; set; }
    }
}
