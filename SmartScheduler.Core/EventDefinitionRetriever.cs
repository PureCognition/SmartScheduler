using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IEventDefinitionRetriever
    {
        EventDefinition Retrieve();
    }

    public class EventDefinitionRetriever : IEventDefinitionRetriever
    {
        private readonly ISessionDefinitionGenerator _sessionDefinitionGenerator;

        public EventDefinitionRetriever(ISessionDefinitionGenerator sessionDefinitionGenerator)
        {
            _sessionDefinitionGenerator = sessionDefinitionGenerator;
        }


        public EventDefinition Retrieve()
        {
            var eventDefinition = new EventDefinition()
            {
                Name = "Career Day",
                NumberOfSlots = 3,
                SessionDefinitions = _sessionDefinitionGenerator.Generate()
            };

            return eventDefinition;

        }
    }
}
