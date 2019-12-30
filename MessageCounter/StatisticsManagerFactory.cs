using MessageCounter.Models;
using MessageCounter.Services.WordsGrouper;
using Newtonsoft.Json;
using System;
using System.Linq;
using MessageCounter.Models.Factories;

namespace MessageCounter
{
    class StatisticsManagerFactory
    {
        private readonly string _fileContent;

        public StatisticsManagerFactory(string fileContent)
        {
            this._fileContent = fileContent;
        }

        public StatisticsManager Create()
        {
            var jsonDataObject = JsonConvert.DeserializeObject<JsonStructureClass>(this._fileContent);

            var messages = jsonDataObject.messages.Select(x => MessageFactory.Create(x.content, x.timestamp_ms, x.sender_name)).ToList();

            var people = jsonDataObject.participants.Select(x => PersonFactory.Create(x.name, messages));

            var days = messages.GroupBy(x => x.DateTime.Date)
                .Select(grouping => DayFactory.Create(grouping.Key, grouping.Select(x => x)));

            var wordsGrouper = new WordsGrouperService(messages);
            var words = wordsGrouper.GroupWords();

            return new StatisticsManager(days, people, words);
        }
    }
}
