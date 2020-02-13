using System;
using System.Linq;
using MessageCounter.Models;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class DayStrings
    {
        public Day Day { get; }

        public DateTime Date => this.Day.DateTime;
        public int NumberOfMessages => this.Day.Messages.Count();

        public DayStrings(Day day) => this.Day = day;
    }
}
