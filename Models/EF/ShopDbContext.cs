namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("name=ShopDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Cate_ID);

            modelBuilder.Entity<Order>()
                .Property(e => e.AmountPd)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Transaction)
                .HasForeignKey(e => e.Trans_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
