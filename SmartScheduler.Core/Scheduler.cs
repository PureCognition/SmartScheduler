using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IScheduler
    {
        Event Schedule();
    }

    public class Scheduler : IScheduler
    {
        private readonly IEventRetriever _eventRetriever;

        public Scheduler(IEventRetriever eventRetriever)
        {
            _eventRetriever = eventRetriever;
        }

        public Event Schedule()
        {
            IDictionary<Attendee, StringCollection> attendeeSessionsScheduled
                = new Dictionary<Attendee, StringCollection>();
            
            IDictionary<Attendee, StringCollection> attendeeSessionTopicsScheduled
                = new Dictionary<Attendee, StringCollection>();

            var retrievedEvent = _eventRetriever.Retrieve();

            ScheduleGrade(retrievedEvent, attendeeSessionsScheduled, attendeeSessionTopicsScheduled, 11);
            ScheduleGrade(retrievedEvent, attendeeSessionsScheduled, attendeeSessionTopicsScheduled, 12);
            ScheduleGrade(retrievedEvent, attendeeSessionsScheduled, attendeeSessionTopicsScheduled, 10);
            ScheduleGrade(retrievedEvent, attendeeSessionsScheduled, attendeeSessionTopicsScheduled, 9);

            return retrievedEvent;
        }

        private void ScheduleGrade(
            Event retrievedEvent, 
            IDictionary<Attendee, StringCollection> attendeeSessionsScheduled, 
            IDictionary<Attendee, StringCollection> attendeeSessionTopicsScheduled, 
            int grade)
        {
            var attendees = retrievedEvent.Attendees.Where(attendee => attendee.Grade == grade);
            for (var slot = 1; slot <= retrievedEvent.NumberOfSlots; slot++)
            {
                ScheduleAttendeesForSlot(attendees, retrievedEvent, attendeeSessionsScheduled, attendeeSessionTopicsScheduled, slot);
            }
        }

        private static void ScheduleAttendeesForSlot(
            IEnumerable<Attendee> attendees,
            Event retrievedEvent, 
            IDictionary<Attendee, StringCollection> attendeeSessionsScheduled,
            IDictionary<Attendee, StringCollection> attendeeSessionTopicsScheduled, 
            int slot)
        {
            foreach (var attendee in attendees)
            {
                if (!attendeeSessionTopicsScheduled.ContainsKey(attendee))
                    attendeeSessionTopicsScheduled.Add(attendee, new StringCollection());
                if (!attendeeSessionsScheduled.ContainsKey(attendee))
                    attendeeSessionsScheduled.Add(attendee, new StringCollection());

                var sessionToSchedule = attendee.TopicPreferences
                    .OrderBy(preference => preference.Priority)
                    .SelectMany(topicPreference => retrievedEvent.Sessions
                        .Where(session => session.Topics
                            .Any(topic => topic.Name == topicPreference.Value.Name
                                          && !session.IsFull
                                          && !attendeeSessionTopicsScheduled[attendee].Contains(topic.Name)))).FirstOrDefault(session => session.Slot == slot
                                                                                                                                         && !attendeeSessionsScheduled[attendee].Contains(session.Name));
                if (sessionToSchedule == null) continue;

                sessionToSchedule.Attendees.Add(attendee);
                attendee.Sessions.Add(sessionToSchedule);

                foreach (var sessionTopic in sessionToSchedule.Topics)
                {
                    attendeeSessionTopicsScheduled[attendee].Add(sessionTopic.Name);
                }

                attendeeSessionsScheduled[attendee].Add(sessionToSchedule.Name);
            }
        }
    }
}
