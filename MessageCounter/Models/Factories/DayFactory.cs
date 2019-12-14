using MessageCounter.Services.WordsGrouper;
using System;
using System.Collections.Generic;

namespace MessageCounter.Models
{
    static class DayFactory
    {
        public static Day Create(DateTime dateTime, IEnumerable<Message> messages)
        {
            var wordsGrouper = new WordsGrouperService(messages);
            return new Day(dateTime, messages, wordsGrouper.GroupWords());
        }
    }
}
