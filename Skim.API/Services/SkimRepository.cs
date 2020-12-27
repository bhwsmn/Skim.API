using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skim.API.DbContexts;
using Skim.API.Entities;

namespace Skim.API.Services
{
    public class SkimRepository : ISkimRepository
    {
        private readonly SkimContext _context;

        public SkimRepository(SkimContext context)
        {
            _context = context;
        }
        
        public async Task<ShortLink> CreateShortLinkAsync(ShortLink shortLink)
        {
            await _context.ShortLinks.AddAsync(shortLink);
            await _context.SaveChangesAsync();
            
            return shortLink;
        }
        
        public async Task<ShortLink> GetShortLinkAsync(string slug)
        {
            var shortLink = await _context.ShortLinks.FirstOrDefaultAsync(sl => sl.Slug == slug);

            return shortLink;
        }

        public async Task<bool> SlugExistsAsync(string slug)
        {
            var slugExists = await _context.ShortLinks.AnyAsync(sl => sl.Slug == slug);

            return slugExists;
        }
    }
}