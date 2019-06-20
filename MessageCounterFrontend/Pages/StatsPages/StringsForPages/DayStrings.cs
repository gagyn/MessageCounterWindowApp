using System;
using MessageCounterBackend.Containers.StatsClasses.Date;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class DayStrings
    {
        public Day Day { get; }

        public DayStrings(Day day) => this.Day = day;

        public Date Date => this.Day.ThisDate;
        public int NumberOfMessages => this.Day.NumberOfMessages;
    }
}
