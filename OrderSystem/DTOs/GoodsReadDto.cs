namespace OrderSystem.DTOs
{
    public class GoodsReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
