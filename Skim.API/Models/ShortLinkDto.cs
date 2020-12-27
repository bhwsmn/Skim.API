using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Skim.API.Models
{
    public class ShortLinkDto
    {
        [Required]
        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$", 
            ErrorMessage = "Invalid Long URL")]
        public string LongUrl { get; set; }
        
        
        [RegularExpression(@"^[a-zA-Z0-9]+$", 
            ErrorMessage = "Only letters and digits are allowed")]
        public string Slug { get; set; }
    }
}