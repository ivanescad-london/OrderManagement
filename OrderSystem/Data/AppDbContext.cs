using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Goods> Goods => Set<Goods>();
        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Supplier)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SupplierId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Goods)
                .WithMany(g => g.Orders)
                .HasForeignKey(o => o.GoodsId);
        }
    }
}
