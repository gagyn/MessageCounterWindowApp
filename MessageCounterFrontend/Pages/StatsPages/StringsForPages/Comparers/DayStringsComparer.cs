using System.Collections;
using System.ComponentModel;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;

namespace MessageCounterFrontend.Pages.StatsPages
{
    class DayStringsComparer : IComparer
    {
        private readonly ListSortDirection direction;

        public DayStringsComparer(ListSortDirection direction) => this.direction = direction;

        public int Compare(object x, object y)
        {
            var firDayStrings = x as DayStrings;
            var secDayStrings = y as DayStrings;

            int compared = firDayStrings.Date.CompareTo(secDayStrings.Date);

            if (direction == ListSortDirection.Descending)
                return compared * -1;
            else
                return compared;
        }
    }
}
