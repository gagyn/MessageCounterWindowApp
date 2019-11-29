using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageCounter.Services.WordsGrouper;

namespace MessageCounter.Models
{
    class Day
    {
        public DateTime DateTime { get; }
        public IEnumerable<Message> Messages { get; }
        public IEnumerable<IGrouping<string, string>> Words { get; }

        public Day(DateTime dateTime, IEnumerable<Message> messages)
        {
            DateTime = dateTime;
            Messages = messages;
            var wordsGrouper = new WordsGrouper(messages);
            Words = wordsGrouper.GroupWords();
        }
    }
}
