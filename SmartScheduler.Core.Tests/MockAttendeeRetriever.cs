using System.Collections.ObjectModel;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core.Tests
{
    public class MockAttendeeRetriever : IAttendeeRetriever
    {
        public Collection<Attendee> Retrieve()
        {
            return TestAttendeeGenerator.Generate();
        }
    }
}
