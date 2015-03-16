using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace SmartScheduler.Core.Data
{
    public class SessionDefinition
    {
        public SessionDefinition()
        {
            Topics = new Collection<SessionTopic>();
        }

        public string Name { get; set; }
        public int Room { get; set; }
        public Collection<SessionTopic> Topics { get; set; }
        public Collection<Presenter> Presenters { get; set; }
        public NameValueCollection AdditionalInformation { get; set; }

    }
}
