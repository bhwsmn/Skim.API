using System.Threading.Tasks;
using Skim.API.Entities;

namespace Skim.API.Services
{
    public interface ISkimRepository
    {
        Task<ShortLink> CreateShortLinkAsync(ShortLink shortLink);
        Task<ShortLink> GetShortLinkAsync(string slug);
        Task<bool> SlugExistsAsync(string slug);
    }
}