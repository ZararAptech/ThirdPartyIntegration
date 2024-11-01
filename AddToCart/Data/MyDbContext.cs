using AddToCart.Model;
using Microsoft.EntityFrameworkCore;

namespace AddToCart.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) { }

        public virtual DbSet<cartitem> Cartitems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCart> ProductCarts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1NHQSUD\\SQLEXPRESS;Initial Catalog=itemcart;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
    }
}
