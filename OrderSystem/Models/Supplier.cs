using System.Text.Json.Serialization;

namespace OrderSystem.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
