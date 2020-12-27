using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skim.API.Entities;
using Skim.API.Helpers;
using Skim.API.Models;
using Skim.API.Services;

namespace Skim.API.Controllers
{
    [ApiController]
    [Route("/shortLinks")]
    public class MainController : ControllerBase
    {
        private readonly ISkimRepository _skimRepository;
        private readonly IMapper _mapper;

        public MainController(ISkimRepository skimRepository, IMapper mapper)
        {
            _skimRepository = skimRepository;
            _mapper = mapper;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<ShortLinkDto>> CreateAsync(ShortLinkDto shortLinkDto)
        {
            if (await _skimRepository.SlugExistsAsync(shortLinkDto.Slug))
            {
                return Conflict();
            }

            // If user provided no slug, generate a random one
            if (string.IsNullOrWhiteSpace(shortLinkDto.Slug))
            {
                for (int length = 2;; length++)
                {
                    shortLinkDto.Slug = SlugGenerator.Generate(length);
                    if (!await _skimRepository.SlugExistsAsync(shortLinkDto.Slug))
                    {
                        break;
                    }
                }
            }

            await _skimRepository.CreateShortLinkAsync(_mapper.Map<ShortLink>(shortLinkDto));

            return CreatedAtAction(actionName: nameof(GetBySlugAsync),
                routeValues: new {slug = shortLinkDto.Slug},
                value: shortLinkDto);
        }

        [HttpHead("{slug}")]
        [HttpGet("{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShortLinkDto>> GetBySlugAsync(string slug)
        {
            var shortLinkFromRepository = await _skimRepository.GetShortLinkAsync(slug);

            if (shortLinkFromRepository == null)
            {
                return NotFound();
            }

            return _mapper.Map<ShortLinkDto>(shortLinkFromRepository);
        }
    }
}