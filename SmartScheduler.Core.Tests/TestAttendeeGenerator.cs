using System.Collections.ObjectModel;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core.Tests
{
    static public class TestAttendeeGenerator
    {
        static public Collection<Attendee> Generate()
        {
            var testAttendees = new Collection<Attendee>()
            {
                new Attendee() {
                    Id = 1, 
                    Name = "Test Student", 
                    Grade = 12, TopicPreferences = new Collection<Preference<SessionTopic>>()
                    {
                        new Preference<SessionTopic>()
                        {
                            Priority = 1,
                            Value = new SessionTopic() {Name = "Software Development"}
                        },
                        new Preference<SessionTopic>()
                        {
                            Priority = 2,
                            Value = new SessionTopic() {Name = "Information Technology"}
                        },
                    }
                },
                new Attendee() {
                    Id = 2, 
                    Name = "Test Student", 
                    Grade = 11, TopicPreferences = new Collection<Preference<SessionTopic>>()
                    {
                        new Preference<SessionTopic>()
                        {
                            Priority = 1,
                            Value = new SessionTopic() {Name = "Information Technology"}
                        },
                        new Preference<SessionTopic>()
                        {
                            Priority = 2,
                            Value = new SessionTopic() {Name = "Software Development"}
                        },
                    }
                },
                new Attendee() {
                    Id = 3, 
                    Name = "Test Student", 
                    Grade = 10, TopicPreferences = new Collection<Preference<SessionTopic>>()
                    {
                        new Preference<SessionTopic>()
                        {
                            Priority = 1,
                            Value = new SessionTopic() {Name = "Accounting"}
                        }
                    }
                },
                new Attendee() {
                    Id = 4, 
                    Name = "Test Student", 
                    Grade = 9, TopicPreferences = new Collection<Preference<SessionTopic>>()
                    {
                        new Preference<SessionTopic>()
                        {
                            Priority = 1,
                            Value = new SessionTopic() {Name = "Education"}
                        }
                    }
                },
                new Attendee() {
                    Id = 5, 
                    Name = "Test Student", 
                    Grade = 12, TopicPreferences = new Collection<Preference<SessionTopic>>()
                    {
                        new Preference<SessionTopic>()
                        {
                            Priority = 1,
                            Value = new SessionTopic() {Name = "Software Development"}
                        }
                    }
                },
                new Attendee() {
                    Id = 6, 
                    Name = "Test Student", 
                    Grade = 11, TopicPreferences = new Collection<Preference<SessionTopic>>()
                    {
                        new Preference<SessionTopic>()
                        {
                            Priority = 1,
                            Value = new SessionTopic() {Name = "Information Technology"}
                        }
                    }
                },
                new Attendee() {
                    Id = 7, 
                    Name = "Test Student", 
                    Grade = 10, TopicPreferences = new Collection<Preference<SessionTopic>>()
                    {
                        new Preference<SessionTopic>()
                        {
                            Priority = 1,
                            Value = new SessionTopic() {Name = "Education"}
                        }
                    }
                },
            };
            return testAttendees;
        }
    }
}
