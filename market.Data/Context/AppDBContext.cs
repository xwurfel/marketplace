using Microsoft.EntityFrameworkCore;
using market.Domain.DataModels;
using market.Domain.DataModels.User;
using market.Domain.DataModels.Product;
using market.Domain.DataModels.Category;

namespace market.Data.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=marketdb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(x => x.Id);

            modelBuilder.Entity<UserModel>().Property(x => x.UserType).HasMaxLength(256);

            modelBuilder.Entity<UserModel>().Property(x => x.Name).HasMaxLength(256);

            modelBuilder.Entity<UserModel>().Property(x => x.UserName).HasMaxLength(64);


            modelBuilder.Entity<ProductCategoryModel>().HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<ProductCategoryModel>()
            .HasOne(pt => pt.Product)
            .WithMany(p => p.Categories)
            .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductCategoryModel>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.CategoryId);
        }
    }
}
