using OrderSystem.Models;
using System.Diagnostics;

namespace OrderSystem.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            Debug.WriteLine("Task SeedAsync : first check there are data");
            if (context.Clients.Any()) return; // already seeded

            // Clients
            var clients = new List<Client>
               {
                   new Client { Name = "Client A" },
                   new Client { Name = "Client B" },
                   new Client { Name = "Client C" },
                   new Client { Name = "Client C" }
               };

            // Suppliers
            var suppliers = new List<Supplier>
               {
                   new Supplier { Name = "Supplier X" },
                   new Supplier { Name = "Supplier Y" },
                   new Supplier { Name = "Supplier Z" }
               };

            // Goods
            var goods = new List<Goods>
               {
                   new Goods { Name = "Laptop", Price = 1200 },
                   new Goods { Name = "Phone", Price = 800 },
                   new Goods { Name = "Monitor", Price = 300 }
               };

            await context.Clients.AddRangeAsync(clients);
            await context.Suppliers.AddRangeAsync(suppliers);
            await context.Goods.AddRangeAsync(goods);

            await context.SaveChangesAsync();

            // Orders (after IDs exist)
            var orders = new List<Order>
               {
                   new Order { OrderDate = DateTime.Now, ClientId = clients[0].Id, SupplierId = suppliers[0].Id, GoodsId = goods[0].Id, Quantity = 9000 },
                   new Order { OrderDate = DateTime.Now, ClientId = clients[1].Id, SupplierId = suppliers[1].Id, GoodsId = goods[1].Id, Quantity = 9111 },
                   new Order { OrderDate = DateTime.Now, ClientId = clients[2].Id, SupplierId = suppliers[2].Id, GoodsId = goods[2].Id, Quantity = 9222 },
                   new Order { OrderDate = DateTime.Now, ClientId = clients[0].Id, SupplierId = suppliers[1].Id, GoodsId = goods[2].Id, Quantity = 9012 },
                   new Order { OrderDate = DateTime.Now, ClientId = clients[1].Id, SupplierId = suppliers[0].Id, GoodsId = goods[2].Id, Quantity = 9102 },
                   new Order { OrderDate = DateTime.Now, ClientId = clients[3].Id, SupplierId = suppliers[2].Id, GoodsId = goods[0].Id, Quantity = 9320 }
               };

            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
    }
}
