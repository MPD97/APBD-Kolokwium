using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public ICollection<ArtistEvent> ArtistEvents { get; set; }
    }
    public class ArtistEvent
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }

        public Event Event { get; set; }
        public Artist Artist { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
    public class Event
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<ArtistEvent> ArtistEvents { get; set; }
    }

    public class Organiser
    {
        public int IdOrganiser { get; set; }
        public string Name { get; set; }
    }
}
