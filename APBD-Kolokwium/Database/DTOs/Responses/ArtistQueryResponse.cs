using Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.DTOs.Responses
{
    public class ArtistQueryResponse
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
