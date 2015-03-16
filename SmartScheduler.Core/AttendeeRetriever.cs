using System;
using System.Collections.ObjectModel;
using System.Data;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IAttendeeRetriever
    {
        Collection<Attendee> Retrieve();
    }

    public class AttendeeRetriever : IAttendeeRetriever
    {
        private readonly IExcelFileReader _excelFileReader;

        public AttendeeRetriever(IExcelFileReader excelFileReader)
        {
            _excelFileReader = excelFileReader;
        }

        public Collection<Attendee> Retrieve()
        {
            var results = new Collection<Attendee>();

            const string filePath = "Data\\Student Survey.xlsx";
            var table = _excelFileReader.Read(filePath).Tables[0];

            foreach (DataRow row in table.Rows)
                results.Add(new Attendee()
                {
                    Name = string.Format("{0} {1}", row[0], row[1]),
                    Id = Convert.ToInt64(row[2]),
                    Grade = Convert.ToInt32(row[3]),
                    Homeroom = Convert.ToInt32(row[4]),
                    TopicPreferences = GetTopicPreferences(table, row)
                });


            return results;
        }

        private Collection<Preference<SessionTopic>> GetTopicPreferences(DataTable table, DataRow row)
        {
            var results = new Collection<Preference<SessionTopic>>();

            for (var index = 5; index <= 65; index++)
            {
                if (!(row[index] is DBNull))
                {
                    var topicName = table.Columns[index].ColumnName;
                    var priority = Convert.ToInt32(row[index]);

                    results.Add(new Preference<SessionTopic>()
                    {
                        Priority = priority,
                        Value = new SessionTopic()
                        {
                            Name = topicName
                        }
                    });
                }
            }

            return results;
        }
    }
}
