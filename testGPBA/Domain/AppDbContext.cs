using Microsoft.EntityFrameworkCore;
using testGPBA.Models;

namespace testGPBA.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "AutoParts Inc.", CreatedDate = DateTime.Now.AddDays(-30) },
                new Supplier { Id = 2, Name = "CarTech Solutions", CreatedDate = DateTime.Now.AddDays(-25) },
                new Supplier { Id = 3, Name = "Vehicle Components Ltd.", CreatedDate = DateTime.Now.AddDays(-20) },
                new Supplier { Id = 4, Name = "Drive Systems Co.", CreatedDate = DateTime.Now.AddDays(-15) },
                new Supplier { Id = 5, Name = "MotoTech Group", CreatedDate = DateTime.Now.AddDays(-10) }
            );

            modelBuilder.Entity<Offer>().HasData(
               
                new Offer { Id = 1, Brand = "Toyota", Model = "Camry", SupplierId = 1, RegistrationDate = DateTime.Now.AddDays(-5) },
                new Offer { Id = 2, Brand = "Honda", Model = "Accord", SupplierId = 1, RegistrationDate = DateTime.Now.AddDays(-4) },
                new Offer { Id = 3, Brand = "Ford", Model = "Focus", SupplierId = 2, RegistrationDate = DateTime.Now.AddDays(-3) },
                new Offer { Id = 4, Brand = "Toyota", Model = "Camry", SupplierId = 1, RegistrationDate = DateTime.Now.AddDays(-5) },
                new Offer { Id = 5, Brand = "Honda", Model = "Accord", SupplierId = 1, RegistrationDate = DateTime.Now.AddDays(-4) },
                new Offer { Id = 6, Brand = "Ford", Model = "Focus", SupplierId = 2, RegistrationDate = DateTime.Now.AddDays(-3) },
                new Offer { Id = 7, Brand = "Toyota", Model = "Camry", SupplierId = 1, RegistrationDate = DateTime.Now.AddDays(-5) },
                new Offer { Id = 8, Brand = "Honda", Model = "Accord", SupplierId = 1, RegistrationDate = DateTime.Now.AddDays(-4) },
                new Offer { Id = 9, Brand = "Ford", Model = "Focus", SupplierId = 4, RegistrationDate = DateTime.Now.AddDays(-3) },
                new Offer { Id = 10, Brand = "Ford", Model = "Focus", SupplierId = 2, RegistrationDate = DateTime.Now.AddDays(-3) },
                new Offer { Id = 11, Brand = "Toyota", Model = "Camry", SupplierId = 1, RegistrationDate = DateTime.Now.AddDays(-5) },
                new Offer { Id = 12, Brand = "Honda", Model = "Accord", SupplierId = 3, RegistrationDate = DateTime.Now.AddDays(-4) },
                new Offer { Id = 13, Brand = "Ford", Model = "Focus", SupplierId = 2, RegistrationDate = DateTime.Now.AddDays(-3) },
                new Offer { Id = 14, Brand = "Ford", Model = "Focus", SupplierId = 2, RegistrationDate = DateTime.Now.AddDays(-3) },
                new Offer { Id = 15, Brand = "BMW", Model = "X5", SupplierId = 5, RegistrationDate = DateTime.Now }
            );
        }
    }
}
