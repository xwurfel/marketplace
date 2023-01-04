using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using market.Domain.DataEntities.Category;
using market.Domain.DataEntities.Product;
using market.Domain.DataEntities.User;
using market.Domain.DataEntities;
using market.Domain.DataEntities.Cart;
using market.Domain.DataEntities.Order;

namespace market.Data.Context
{
    public class AppDBContext : IdentityDbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<CartEntity> Carts { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderDetailsEntity> OrderDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=marketdb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategoryModel>().HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<ProductCategoryModel>()
            .HasOne(pt => pt.Product)
            .WithMany(p => p.Categories)
            .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductCategoryModel>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.CategoryId);

            modelBuilder.Entity<CartEntity>().HasKey(x => x.RecordId);

            modelBuilder.Entity<OrderEntity>().HasKey(x => x.OrderId);

            modelBuilder.Entity<OrderDetailsEntity>().HasKey(x => x.OrderDetailId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
