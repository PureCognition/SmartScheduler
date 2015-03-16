using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartScheduler.Core.Tests
{
    [TestClass]
    public class When_retrieving_an_event_definition
    {
        [TestMethod]
        public void is_should_not_be_null()
        {
            var eventDefinitionRetriever = new EventDefinitionRetriever
                (new SessionDefinitionGenerator(
                    new PresenterRetriever(
                        new ExcelFileReader())));

            var eventDefinition = eventDefinitionRetriever.Retrieve();

            Assert.IsNotNull(eventDefinition);
        }
    }
}
