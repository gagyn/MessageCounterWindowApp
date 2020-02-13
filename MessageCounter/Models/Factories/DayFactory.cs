using System;
using System.Collections.Generic;

namespace MessageCounter.Models.Factories
{
    static class DayFactory
    {
        public static Day Create(DateTime dateTime, IEnumerable<Message> messages)
        {
            return new Day(dateTime, messages);
        }
    }
}
