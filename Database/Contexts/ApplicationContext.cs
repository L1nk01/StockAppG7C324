using Microsoft.EntityFrameworkCore;
using Database.Entities;

namespace Database.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            #region Tables
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Product>().HasKey(product => product.Id); // lambda
            modelBuilder.Entity<Product>().HasKey(category => category.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<Category>()
                .HasMany<Product>(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Properties Configuration

            #region Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name).HasMaxLength(150);
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                .Property(c => c.Name).HasMaxLength(150);
            #endregion

            #endregion
        }
    }
}
