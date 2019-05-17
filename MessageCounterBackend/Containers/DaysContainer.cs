using System;
using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.JsonStructure;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterBackend.StatContainers
{
    public class DaysContainer : Container
    {
        public List<Day> Days { get; }
        public List<Day> SortedDays { get; }
        public Day DayWithMaxNumberOfMessages { get; }

        public DaysContainer(JsonStructureClass jsonObject) 
            : this(jsonObject.messages.ToList()) { }
        public DaysContainer(List<Message> messages)
        {
            Days = MakeDaysList(messages);
            SortedDays = SortDaysList(Days);
            DayWithMaxNumberOfMessages = SortedDays.First();
        }

        private List<Day> MakeDaysList(List<Message> messages)
        {
            // group into single days with their messages
            var grouped = messages.GroupBy(x => BeginOfDay(MiliSecToDate(x.timestamp_ms)));
            var days = new List<Day>();

            foreach (var d in grouped)
                days.Add(new Day(d.ToList(), d.Key));

            return days;
        }

        private List<Day> SortDaysList(List<Day> days)
            => days.OrderByDescending(x => x.NumberOfMessages).ToList();

        private DateTime MiliSecToDate(ulong mili)
            => new DateTime(1970, 1, 1).AddMilliseconds(mili);

        private DateTime BeginOfDay(DateTime date)
            => new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
    }
}
