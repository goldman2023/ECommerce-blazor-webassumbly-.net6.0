using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dreamer.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Vendor", NormalizedName = "VENDOR", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
        public DbSet<Area> Area { get; set; }
        public DbSet<CustomerMaster> CustomerMaster { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
        public DbSet<BillingAddress> BillingAddress { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPictureMapping> ProductPictureMapping { get; set; }
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<ProductVariation> ProductVariation { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}
