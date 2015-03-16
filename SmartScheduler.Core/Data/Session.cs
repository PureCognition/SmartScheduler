using System.Collections.ObjectModel;

namespace SmartScheduler.Core.Data
{
    public class Session
    {
        public Session()
        {
            Attendees = new Collection<Attendee>();
            Topics = new Collection<SessionTopic>();
        }

        public string Name { get; set; }
        public int Slot { get; set; }
        public Collection<Attendee> Attendees { get; set; }
        public int MaxNumberOfAttendees { get; set; }
        public Collection<SessionTopic> Topics { get; set; }
        public SessionDefinition Definition { get; set; }
        public bool IsFull
        {
            get
            {
                return Attendees.Count >= MaxNumberOfAttendees;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} with {1} attenddees.", Name, Attendees.Count);
        }
    }
}
