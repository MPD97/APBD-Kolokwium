using System.Collections.Generic;

namespace Database.Entities
{
    public class Organiser
    {
        public int IdOrganiser { get; set; }
        public string Name { get; set; }
        public ICollection<EventOrganiser> EventOrganisers { get; set; }

    }
}
