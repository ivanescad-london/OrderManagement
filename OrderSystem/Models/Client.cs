using System.Text.Json.Serialization;

namespace OrderSystem.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Navigation
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
