using Database.DTOs.Requests;
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
    public class ArtistManageService : IArtistManageService
    {
        private readonly EventContext _eventContext;

        public ArtistManageService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }
        public async Task<ArtistChangePerformanceDateResponse> ChangePerfomanceDate(ArtistChangePerformanceDateRequest command)
        {
            var artistEvent = await _eventContext.ArtistEvents.FirstOrDefaultAsync(
                ae => ae.IdArtist == command.IdArtist && ae.IdEvent == command.IdEvent);
            if (artistEvent == null)
            {
                return null;
            }

            var event1 = await _eventContext.Events.FirstOrDefaultAsync(e => e.IdEvent == artistEvent.IdEvent);
            if (event1 == null)
            {
                return null;
            }

            if (event1.StartDate >= DateTime.Now)
            {
                return null;
            }

            if (command.PerformanceDate <= event1.StartDate || command.PerformanceDate >= event1.EndDate)
            {
                return null;
            }

            artistEvent.PerformanceDate = command.PerformanceDate;
            _eventContext.Entry(artistEvent).State = EntityState.Modified;

            if (await _eventContext.SaveChangesAsync() == 0)
            {
                return null;
            }

            return new ArtistChangePerformanceDateResponse
            {
                IdArtist = artistEvent.IdArtist,
                IdEvent = event1.IdEvent,
                PerformanceDate = artistEvent.PerformanceDate
            };
        }
    }
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
