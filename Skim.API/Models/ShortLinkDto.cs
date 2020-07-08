using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Skim.API.Models
{
    public class ShortLinkDto
    {
        [Required]
        [DataType(DataType.Url)]
        [JsonPropertyName("fullLink")]
        public string FullLink { get; set; }
        
        
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only letters and digits are allowed.")]
        [JsonPropertyName("shortString")]
        public string ShortString { get; set; }
    }
}