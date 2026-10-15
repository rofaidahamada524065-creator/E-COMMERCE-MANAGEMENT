using E_COMMERCE_MANAGEMENT.Model;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE_MANAGEMENT.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(a=>a.Products).WithOne(a=>a.Category).HasForeignKey(a=>a.CatgoryID);
            modelBuilder.Entity<User>().HasMany(a=>a.Orders).WithOne(a=>a.User).HasForeignKey(a=>a.UserId);
            modelBuilder.Entity<Order>().HasMany(a=>a.orderItems).WithOne(a=>a.Order).HasForeignKey(a=>a.OrderId);
            modelBuilder.Entity<Product>().HasMany(a=>a.orderItems).WithOne(a=>a.Product).HasForeignKey(a=>a.ProdactId);

            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(a => a.Email).IsUnique();

              
                
                
        }
    }
}
