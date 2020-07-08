using System;
using System.ComponentModel.DataAnnotations;

namespace Skim.API.Entities
{
    public class ShortLink
    {
        public Guid Id { get; set; }
        
        [Required]
        public string FullLink { get; set; }

        [Required]
        public string ShortString { get; set; }
    }
}