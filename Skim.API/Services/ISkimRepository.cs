using System.Threading.Tasks;
using Skim.API.Entities;

namespace Skim.API.Services
{
    public interface ISkimRepository
    {
        Task<ShortLink> GetShortLinkAsync(string shortString);
        Task<ShortLink> AddShortLinkAsync(ShortLink shortLink);
        Task<bool> ShortStringExistsAsync(string shortString);
        bool Save();
    }
}