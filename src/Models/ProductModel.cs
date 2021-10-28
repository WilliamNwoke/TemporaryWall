using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Artist { get; set; }
        
        [Required]
        [Url]
        [JsonPropertyName("img")]
        public string Image { get; set; }

        [Required]
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public int[] Ratings { get; set; }
        public string[] Comments { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}