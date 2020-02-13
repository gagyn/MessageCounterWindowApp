using System.Collections;
using System.ComponentModel;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages.Comparers
{
    class DayStringsComparer : IComparer
    {
        private readonly ListSortDirection _direction;

        public DayStringsComparer(ListSortDirection direction) => this._direction = direction;

        public int Compare(object x, object y)
        {
            var firDayStrings = x as DayStrings;
            var secDayStrings = y as DayStrings;

            var compared = firDayStrings.Date.CompareTo(secDayStrings.Date);

            if (_direction == ListSortDirection.Descending)
                return compared * -1;

            return compared;
        }
    }
}
