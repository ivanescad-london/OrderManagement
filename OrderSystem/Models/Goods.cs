using System.Text.Json.Serialization;

namespace OrderSystem.Models
{
    public class Goods
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
