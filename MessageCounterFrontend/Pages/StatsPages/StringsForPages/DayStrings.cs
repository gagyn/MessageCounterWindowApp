using System;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class DayStrings
    {
        public Day Day { get; }

        public DayStrings(Day day) => this.Day = day;

        public string Date => this.Day.ThisDateTime.ToShortDateString();
        public int NumberOfMessages => this.Day.NumberOfMessages;

    }
}
