using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalDetail>()
                .HasOne(rd => rd.Product)
                .WithMany()
                .HasForeignKey(rd => rd.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RentalDetail>()
                .HasOne(rd => rd.Rental)
                .WithMany(r => r.RentalDetails)
                .HasForeignKey(rd => rd.RentalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}