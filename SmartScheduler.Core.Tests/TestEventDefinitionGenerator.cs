using System.Collections.ObjectModel;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core.Tests
{
    public static class TestEventDefinitionGenerator
    {
        public static EventDefinition Generate()
        {
            var testEventDefinition = new EventDefinition()
            {
                Name = "Career Fair",
                NumberOfSlots = 3,
                SessionDefinitions = new Collection<SessionDefinition>()
                {
                    new SessionDefinition()
                    {
                        Name = "Nathan Lauffer",
                        Topics = new Collection<SessionTopic>()
                        {
                            new SessionTopic() {Name = "Software Development"}
                        }
                    },
                    new SessionDefinition()
                    {
                        Name = "Michelle Lauffer",
                        Topics = new Collection<SessionTopic>()
                        {
                            new SessionTopic() {Name = "Information Technology"}
                        }
                    },
                    new SessionDefinition()
                    {
                        Name = "Boring Guy",
                        Topics = new Collection<SessionTopic>()
                        {
                            new SessionTopic() {Name = "Accounting"}
                        }
                    },
                    new SessionDefinition()
                    {
                        Name = "David McCleary",
                        Topics = new Collection<SessionTopic>()
                        {
                            new SessionTopic() {Name = "Education"}
                        }
                    }
                }
            };

            return testEventDefinition;

        }
    }
}
