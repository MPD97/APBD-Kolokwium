using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
    }
    public class Event
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
