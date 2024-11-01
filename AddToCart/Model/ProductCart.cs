using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AddToCart.Model
{
    public class ProductCart
    {
        [Key]
        public int userId { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("title")]
        public string title { get; set; }
        [JsonPropertyName("price")]
        public double price { get; set; }
        [JsonPropertyName("description")]
        public string description { get; set; }
        [JsonPropertyName("category")]
        public string category { get; set; }
        [JsonPropertyName("image")]
        public string image { get; set; }
        
        public bool? isPurchased { get; set; }
    }
}
