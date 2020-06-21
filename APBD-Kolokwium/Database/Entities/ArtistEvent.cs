using System;

namespace Database.Entities
{
    public class ArtistEvent
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }

        public Event Event { get; set; }
        public Artist Artist { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
