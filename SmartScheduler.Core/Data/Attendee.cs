using System.Collections.ObjectModel;

namespace SmartScheduler.Core.Data
{
    public class Attendee
    {
        public Attendee()
        {
            TopicPreferences = new Collection<Preference<SessionTopic>>();
            Sessions = new Collection<Session>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Homeroom { get; set; }
        public Collection<Preference<SessionTopic>> TopicPreferences { get; set; }
        public Collection<Session> Sessions { get; set; }

        public override string ToString()
        {
            return string.Format("{0} scheduled for {1} sessions", Name, Sessions.Count);
        }
    }
}
