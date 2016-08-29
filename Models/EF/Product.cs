namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }

        public int? Cate_ID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        [StringLength(250)]
        public string ImageLink { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? View { get; set; }

        [Column(TypeName = "ntext")]
        public string Describe { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
