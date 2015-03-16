using System.Collections.ObjectModel;

namespace SmartScheduler.Core.Data
{
    public class EventDefinition
    {
        public string Name { get; set; }
        public int NumberOfSlots { get; set; }
        public Collection<SessionDefinition> SessionDefinitions { get; set; }
    }
}
