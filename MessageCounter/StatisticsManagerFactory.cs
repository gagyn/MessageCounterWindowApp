using System;
using System.Collections.Generic;
using MessageCounter.Models;
using MessageCounter.Services.WordsGrouper;
using Newtonsoft.Json;
using System.Linq;
using MessageCounter.Models.Factories;

namespace MessageCounter
{
    public class StatisticsManagerFactory
    {
        private readonly JsonStructureClass _jsonDataObject;

        public StatisticsManagerFactory(string fileContent)
        {
            this._jsonDataObject = JsonConvert.DeserializeObject<JsonStructureClass>(fileContent);
        }

        public StatisticsManager Create()
        {
            var messages = CreateMessages().ToList();
            var people = CreatePeople(messages);
            var days = CreateDays(messages);
            var words = CreateWords(messages);

            return new StatisticsManager(days, people, words, ReloadStats);
        }

        private IEnumerable<Message> CreateMessages()
        {
            return _jsonDataObject.messages.Select(x => MessageFactory.Create(x.content, x.timestamp_ms, x.sender_name));
        }
        
        private IEnumerable<Person> CreatePeople(IReadOnlyCollection<Message> messages)
        {
            return _jsonDataObject.participants.Select(x => PersonFactory.Create(x.name, messages));
        }

        private IEnumerable<Day> CreateDays(IEnumerable<Message> messages)
        {
            return messages.GroupBy(x => x.DateTime.Date)
                .Select(grouping => DayFactory.Create(grouping.Key, grouping.Select(x => x)));
        }

        private IOrderedEnumerable<Word> CreateWords(IEnumerable<Message> messages)
        {
            var wordsGrouper = new WordsGrouperService(messages);
            return wordsGrouper.GroupWords();
        }

        private void ReloadStats(StatisticsManager manager)
        {
            manager.Words = CreateWords(CreateMessages());
        }
    }
}
