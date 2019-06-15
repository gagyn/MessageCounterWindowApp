using System;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterFrontend.StatsPages.OneItemPages
{
    class DayStrings
    {
        public Day Day { get; }

        public DayStrings(Day day) => this.Day = day;

        public string Date => this.Day.ThisDateTime.ToShortDateString();
        public int NumberOfMessages => this.Day.NumberOfMessages;

    }
}
