using SmartScheduler.Core.Data;

namespace SmartScheduler.Core.Tests
{
    public class MockEventDefinitionRetriever : IEventDefinitionRetriever
    {
        public EventDefinition Retrieve()
        {
            return TestEventDefinitionGenerator.Generate();
        }
    }
}
