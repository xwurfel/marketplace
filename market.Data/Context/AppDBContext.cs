using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using market.Domain.DataEntities.Category;
using market.Domain.DataEntities.Product;
using market.Domain.DataEntities.User;
using market.Domain.DataEntities;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
