using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Entities;
using Services;
using Database.DTOs.Requests;

namespace APBD_Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistQueryService _artistQueryService;
        private readonly IArtistManageService _artistManageService;


        public ArtistsController(IArtistQueryService artistQueryService,
            IArtistManageService artistManageService)
        {
            _artistQueryService = artistQueryService;
            _artistManageService = artistManageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artist = await _artistQueryService.GetAsync(id);

            if (artist == null)
            {
                return NotFound("Nie znaleziono artysty o podanym id.");
            }

            return Ok(artist);
        }
        //PUT /api/artists/10/events/1 HTTP/1.1 
        [HttpPut("{artistId}/events/{eventId}")]
        public async Task<IActionResult> PutArtist(int artistId, int eventId, DateTime performanceDate)
        {
            if (performanceDate == null)
            {
                return BadRequest("Podaj datę występu");
            }
            var result = await _artistManageService.ChangePerfomanceDate(new ArtistChangePerformanceDateRequest
            {
                IdArtist = artistId,
                IdEvent = eventId,
                PerformanceDate = performanceDate
            });

            return result switch
            {
                SuccessResponse _ => Ok(result),
                ErrorResponse _ => BadRequest(result),
                InternalError _ => StatusCode(500, result),
                _ => NotFound()
            };
        }
    }
}
