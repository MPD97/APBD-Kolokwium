using System;
using System.Collections.Generic;
using System.Text;

namespace Database.DTOs.Responses
{
    public class ArtistChangePerformanceDateResponse
    {
        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}
