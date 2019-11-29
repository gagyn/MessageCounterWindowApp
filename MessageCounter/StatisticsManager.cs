using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageCounter.Models;
using Newtonsoft.Json;

namespace MessageCounter
{
    class StatisticsManager
    {
        public readonly IEnumerable<Day> Days;
        public readonly IEnumerable<Person> People;
        public readonly IEnumerable<IGrouping<string, string>> Words;

        public StatisticsManager(string fileContent)
        {
            var jsonDataObject = JsonConvert.DeserializeObject<JsonStructureClass>(fileContent);
            Days = new List<Day>();
            jsonDataObject.messages.Select(x => x.timestamp_ms);
        }
    }
}
