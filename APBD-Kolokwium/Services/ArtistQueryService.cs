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
            
            artist.ArtistEvents.Where(a => a.PerformanceDate < DateTime.Now) // W których brał udział.
                .OrderByDescending(a => a.PerformanceDate).ToArray();

            return new ArtistQueryResponse
            {
                IdArtist = artist.IdArtist,
                Nickname = artist.Nickname,
                ArtistEvents = artist.ArtistEvents
            };
                
        }
    }
}
