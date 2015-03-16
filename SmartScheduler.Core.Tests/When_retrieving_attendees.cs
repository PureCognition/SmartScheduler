using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartScheduler.Core.Tests
{
    [TestClass]
    public class When_retrieving_attendees
    {
        [TestMethod]
        public void the_right_number_of_attendees_should_be_retrieved()
        {
            var attendeeRetriever = new AttendeeRetriever(new ExcelFileReader());
            var attendees = attendeeRetriever.Retrieve();
            Assert.AreEqual(1501, attendees.Count);
        }
    }
}
