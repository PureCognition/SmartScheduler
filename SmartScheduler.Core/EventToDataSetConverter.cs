using System.Data;
using System.Linq;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IEventToDataSetConverter
    {
        DataSet Convert(Event eventToConvert);
    }

    public class EventToDataSetConverter : IEventToDataSetConverter
    {
        public DataSet Convert(Event eventToConvert)
        {
            var eventDataSet = new DataSet(eventToConvert.Name);

            AddAttendeeTable(eventToConvert, eventDataSet);
            AddSessionTable(eventToConvert, eventDataSet);

            return eventDataSet;
        }

        private static void AddSessionTable(Event eventToSave, DataSet eventDataSet)
        {
            var sessionTable = new DataTable("Sessions");

            sessionTable.Columns.Add("Name");
            sessionTable.Columns.Add("Slot");
            sessionTable.Columns.Add("Number of Attendees");

            foreach (var session in eventToSave.Sessions)
            {
                sessionTable.Rows.Add(session.Name, session.Slot, session.Attendees.Count);
            }

            eventDataSet.Tables.Add(sessionTable);
        }

        private static void AddAttendeeTable(Event eventToSave, DataSet eventDataSet)
        {
            DataTable attendeeTable = new DataTable("Attendees");

            attendeeTable.Columns.Add("Name");
            attendeeTable.Columns.Add("Grade");
            attendeeTable.Columns.Add("Homeroom");
            attendeeTable.Columns.Add("Slot 1");
            attendeeTable.Columns.Add("Slot 2");
            attendeeTable.Columns.Add("Slot 3");

            foreach (var attendee in eventToSave.Attendees)
            {
                attendeeTable.Rows.Add
                    (attendee.Name,
                        attendee.Grade,
                        attendee.Homeroom,
                        GetSlot(attendee, 1),
                        GetSlot(attendee, 2), GetSlot(attendee, 3));
            }

            eventDataSet.Tables.Add(attendeeTable);
        }

        private static string GetSlot(Attendee attendee, int slot)
        {
            var slotInformation = "";
            var sessionInSlot = attendee.Sessions.FirstOrDefault(session => session.Slot == slot);
            if (sessionInSlot != null)
                slotInformation = string.Format("{0}", sessionInSlot.Name);

            return slotInformation;
        }
    }
}
