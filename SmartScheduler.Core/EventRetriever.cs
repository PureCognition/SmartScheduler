using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IEventRetriever
    {
        Event Retrieve();
    }

    public class EventRetriever : IEventRetriever
    {
        private readonly IEventInitializer _eventInitializer;
        private readonly IAttendeeRetriever _attendeeRetriever;

        public EventRetriever(IEventInitializer eventInitializer, IAttendeeRetriever attendeeRetriever)
        {
            _eventInitializer = eventInitializer;
            _attendeeRetriever = attendeeRetriever;
        }

        public Event Retrieve()
        {
            var result = _eventInitializer.Initialize();
            result.Attendees = _attendeeRetriever.Retrieve();
            const int maxNumberOfAttendeesPerSession = 30; //result.Attendees.Count / result.Definition.SessionDefinitions.Count;

            foreach (var session in result.Sessions)
                session.MaxNumberOfAttendees = maxNumberOfAttendeesPerSession;

            return result;
        }
    }
}
