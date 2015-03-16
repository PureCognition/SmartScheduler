using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartScheduler.Core.Tests
{
    [TestClass]
    public class When_scheduling_for_an_event
    {
        [TestMethod]
        public void it_should_return_an_event()
        {

            var scheduler = new Scheduler(new EventRetriever(
                new EventInitializer(
                    new EventDefinitionRetriever(
                        new SessionDefinitionGenerator(
                            new PresenterRetriever(
                                new ExcelFileReader())))), 
                                new AttendeeRetriever(
                                    new ExcelFileReader())));

            var testEvent = scheduler.Schedule();

            Assert.IsNotNull(testEvent);
        }
    }
}
