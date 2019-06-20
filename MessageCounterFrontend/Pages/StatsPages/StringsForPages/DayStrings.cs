using MessageCounterBackend.Containers.StatsClasses;
using MessageCounterBackend.Containers.StatsClasses.DateNameSpace;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class DayStrings
    {
        public Day Day { get; }

        public Date Date => this.Day.ThisDate;
        public int NumberOfMessages => this.Day.NumberOfMessages;

        public DayStrings(Day day) => this.Day = day;
    }
}
