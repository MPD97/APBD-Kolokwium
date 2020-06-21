using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Entities;
using Services;

namespace APBD_Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistQueryService _artistQueryService;

        public ArtistsController(IArtistQueryService artistQueryService)
        {
            _artistQueryService = artistQueryService;
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


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutArtist(int id, Artist artist)
        //{
        //    if (id != artist.IdArtist)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(artist).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ArtistExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
    }
}
