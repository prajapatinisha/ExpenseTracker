namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Expenses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expenses()
        {
            Categories = new HashSet<Categories>();
            ExpenseLimits = new HashSet<ExpenseLimits>();
        }

        [Key]
        public int ExpId { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        [Required]
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categories> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseLimits> ExpenseLimits { get; set; }
    }
}
