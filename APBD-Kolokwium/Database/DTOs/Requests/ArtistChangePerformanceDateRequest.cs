using System;
using System.Collections.Generic;
using System.Text;

namespace Database.DTOs.Requests
{
    public class ArtistChangePerformanceDateRequest
    {
        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}
