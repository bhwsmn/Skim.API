using System;

namespace Skim.API.Entities
{
    public class ShortLink
    {
        public Guid Id { get; set; }
        public string LongUrl { get; set; }
        public string Slug { get; set; }
    }
}