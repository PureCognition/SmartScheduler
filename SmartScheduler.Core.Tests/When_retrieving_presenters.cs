using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartScheduler.Core.Tests
{
    [TestClass]
    public class When_retrieving_presenters
    {
        [TestMethod]
        public void the_right_number_of_presenters_should_be_present()
        {
            var presenterRetriever = new PresenterRetriever(new ExcelFileReader());

            var presenters = presenterRetriever.Retrieve();

            Assert.AreEqual(presenters.Count, 66);
        }
    }
}
