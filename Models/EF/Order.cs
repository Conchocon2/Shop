namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public int Product_ID { get; set; }

        public int Trans_ID { get; set; }

        public int? Number { get; set; }

        public decimal? AmountPd { get; set; }

        public int? Discount { get; set; }

        public virtual Product Product { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
