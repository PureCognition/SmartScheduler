using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartScheduler.Core.Tests
{
    [TestClass]
    public class When_generating_a_session_definitions
    {
        [TestMethod]
        public void the_right_number_of_sessions_should_be_generated()
        {
            var sessionDefinitionGenerator =
                new SessionDefinitionGenerator(new PresenterRetriever(new ExcelFileReader()));

            var sessionDefinitions = sessionDefinitionGenerator.Generate();

            Assert.AreEqual(sessionDefinitions.Count, 60);
        }
    }
}
