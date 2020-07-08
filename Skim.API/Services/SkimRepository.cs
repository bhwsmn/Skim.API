using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skim.API.DbContexts;
using Skim.API.Entities;
using Skim.API.Helpers;

namespace Skim.API.Services
{
    public class SkimRepository : ISkimRepository, IDisposable
    {
        private readonly SkimContext _context;

        public SkimRepository(SkimContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public async Task<ShortLink> GetShortLinkAsync(string shortString)
        {
            var shortLink = await _context.ShortLinks.FirstOrDefaultAsync(sl => sl.ShortString == shortString);

            return shortLink;
        }

        public async Task<ShortLink> AddShortLinkAsync(ShortLink shortLink)
        {
            if (string.IsNullOrWhiteSpace(shortLink.ShortString))
            {
                shortLink.ShortString = await GenerateShortStringAsync();
            }
            
            await _context.ShortLinks.AddAsync(shortLink);
            
            return shortLink;
        }

        public async Task<bool> ShortStringExistsAsync(string shortString)
        {
            var slugExists = await _context.ShortLinks.AnyAsync(sl => sl.ShortString == shortString);

            return slugExists;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
        
        public void Dispose()
        {
            Save();
            _context?.Dispose();
        }
        
        private async Task<string> GenerateShortStringAsync()
        {
            var shortString = "";
            do
            {
                shortString = ShortStringGenerator.Generate(minLength: 3, maxLength: 6);

            } while (await _context.ShortLinks.AnyAsync(sl => sl.ShortString == shortString));

            return shortString;
        }

    }
}