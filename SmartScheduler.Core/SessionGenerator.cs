using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface ISessionDefinitionGenerator
    {
        Collection<SessionDefinition> Generate();
    }

    public class SessionDefinitionGenerator : ISessionDefinitionGenerator
    {
        private readonly PresenterRetriever _presenterRetriever;

        public SessionDefinitionGenerator(PresenterRetriever presenterRetriever)
        {
            _presenterRetriever = presenterRetriever;
        }

        public Collection<SessionDefinition> Generate()
        {
            var results = new Collection<SessionDefinition>();
            var presenters = _presenterRetriever.Retrieve();

            var sharedRooms = new Dictionary<int, Collection<Presenter>>();

            foreach (var presenter in presenters)
            {
                if (!sharedRooms.ContainsKey(presenter.Room))
                    sharedRooms.Add(presenter.Room, new Collection<Presenter>());

                sharedRooms[presenter.Room].Add(presenter);
            }

            foreach (var item in sharedRooms)
            {
                results.Add(new SessionDefinition()
                {
                    Presenters = item.Value,
                    Room = item.Key,
                    Topics = GenerateTopicsFromPresenters(item.Value),
                    Name = GenerateNameFromRoomAndPresenters(item.Key, item.Value)
                });
            }

            return results;
        }

        private string GenerateNameFromRoomAndPresenters(int room, Collection<Presenter> presenters)
        {
            var topics = GetTopicValuesFromPresenters(presenters);

            return string.Format("Room {0}: {1}", room, GenerateTopicListText(topics));
        }

        private string GenerateTopicListText(StringCollection topics)
        {
            var builder = new StringBuilder();

            for (var index = 0; index < topics.Count; index++)
            {
                builder.Append(topics[index].Trim());

                if (index != topics.Count - 1)
                    builder.Append(", ");
            }


            return builder.ToString();
        }


        private Collection<SessionTopic> GenerateTopicsFromPresenters(Collection<Presenter> presenters)
        {
            var results = new Collection<SessionTopic>();

            var topics = GetTopicValuesFromPresenters(presenters);

            foreach (var topic in topics)
                results.Add(new SessionTopic() {Name = topic});

            return results;
        }

        private static StringCollection GetTopicValuesFromPresenters(Collection<Presenter> presenters)
        {
            var topics = new StringCollection();

            foreach (var presenter in presenters.Where(presenter => !topics.Contains(presenter.Topic)))
            {
                topics.Add(presenter.Topic);
            }
            return topics;
        }
    }
}
