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
}
