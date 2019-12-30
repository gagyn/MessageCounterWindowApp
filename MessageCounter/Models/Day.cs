using System;
using System.Collections.Generic;

namespace MessageCounter.Models
{
    public class Day
    {
        public DateTime DateTime { get; }
        public IEnumerable<Message> Messages { get; }

        public Day(DateTime dateTime, IEnumerable<Message> messages)
        {
            DateTime = dateTime;
            Messages = messages;
        }
    }
}
