namespace OrderSystem.DTOs
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string Client { get; set; } = "";
        public string Supplier { get; set; } = "";
        public string Goods { get; set; } = "";

        public int Quantity { get; set; }
    }
}
