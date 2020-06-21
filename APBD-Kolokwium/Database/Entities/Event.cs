using System;
using System.Collections.Generic;

namespace Database.Entities
{
    public class Event
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<ArtistEvent> ArtistEvents { get; set; }
        public ICollection<EventOrganiser> EventOrganisers { get; set; }

    }
}
