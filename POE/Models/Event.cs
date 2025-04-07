using static System.Net.Mime.MediaTypeNames;

namespace CLDVapp.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public List<Booking> Booking { get; set; } = new();
    }
}
