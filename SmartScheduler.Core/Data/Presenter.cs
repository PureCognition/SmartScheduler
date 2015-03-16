using System.Collections.Specialized;

namespace SmartScheduler.Core.Data
{
    public class Presenter
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Room { get; set; }
        public string Topic { get; set; }
        public string Category { get; set; }
        public NameValueCollection AdditionalInformation { get; set; }
    }
}
