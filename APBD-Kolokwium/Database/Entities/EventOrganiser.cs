namespace Database.Entities
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }

        public Event Event { get; set; }
        public Organiser Organiser { get; set; }
    }
}
