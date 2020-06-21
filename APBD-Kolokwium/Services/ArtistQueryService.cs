using Database.DTOs.Responses;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ArtistQueryService : IArtistQueryService
    {
        private readonly EventContext _eventContext;

        public ArtistQueryService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public async Task<ArtistQueryResponse> GetAsync(int id)
        {
            var artist = await _eventContext.Artists.FirstOrDefaultAsync(
                a => a.IdArtist == id);
           
            if (artist == null)
                return null;

            var events = await _eventContext.Events.Where(a =>
             _eventContext.ArtistEvents.Any(ae => ae.IdEvent == a.IdEvent && artist.IdArtist == ae.IdArtist)
             == true)
                .OrderByDescending(e => e.StartDate)
                .ToArrayAsync();
           
            return new ArtistQueryResponse
            {
                IdArtist = artist.IdArtist,
                Nickname = artist.Nickname,
                Events = events
            };
                
        }
    }
}
