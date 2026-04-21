namespace OrderSystem.DTOs
{
    public class OrderCreateDto
    {
        public DateTime OrderDate { get; set; }

        public int ClientId { get; set; }
        public int SupplierId { get; set; }
        public int GoodsId { get; set; }

        public int Quantity { get; set; }
    }
}
