using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IEventInitializer
    {
        Event Initialize();
    }

    public class EventInitializer : IEventInitializer
    {
        private readonly IEventDefinitionRetriever _eventDefinitionRetriever;

        public EventInitializer(IEventDefinitionRetriever eventDefinitionRetriever)
        {
            _eventDefinitionRetriever = eventDefinitionRetriever;
        }

        public Event Initialize()
        {
            var eventDefinition = _eventDefinitionRetriever.Retrieve();
            var result = new Event {
                Name = eventDefinition.Name,
                Definition = eventDefinition,
                NumberOfSlots = eventDefinition.NumberOfSlots};

            for (var slot = 1; slot <= eventDefinition.NumberOfSlots; slot++)
            {
                foreach (var sessionDefinition in eventDefinition.SessionDefinitions)
                {
                    result.Sessions.Add(new Session()
                    {
                        Name = sessionDefinition.Name,
                        Slot = slot,
                        Topics = sessionDefinition.Topics,
                        Definition = sessionDefinition
                    });
                }
            }

            return result;
        }
    }
}
