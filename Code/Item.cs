using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI_295.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } //True oder false, keine Zahlen!
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual ItemCategory? Category { get; set; }
    }
}
