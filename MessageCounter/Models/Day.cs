using System;
using System.Collections.Generic;

namespace MessageCounter.Models
{
    class Day
    {
        public DateTime DateTime { get; }
        public IEnumerable<Message> Messages { get; }
        public IEnumerable<Word> Words { get; }

        public Day(DateTime dateTime, IEnumerable<Message> messages, IEnumerable<Word> words)
        {
            DateTime = dateTime;
            Messages = messages;
            Words = words;
        }
    }
}
