namespace OrderSystem.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        // ----- Client -----
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        // ----- Supplier -----
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        // ----- Goods -----
        public int GoodsId { get; set; }
        public Goods? Goods { get; set; }

        public int Quantity { get; set; }

    }
}
