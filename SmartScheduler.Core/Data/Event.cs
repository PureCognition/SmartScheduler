using System.Collections.ObjectModel;

namespace SmartScheduler.Core.Data
{
    public class Event
    {
        public Event()
        {
            Sessions = new Collection<Session>();
            Attendees = new Collection<Attendee>();
        }

        public string Name { get; set; }
        public int NumberOfSlots { get; set; }
        public EventDefinition Definition { get; set; }
        public Collection<Session> Sessions { get; set; }
        public Collection<Attendee> Attendees { get; set; }
    }
}
