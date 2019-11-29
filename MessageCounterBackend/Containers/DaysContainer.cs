using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.Containers.StatsClasses;
using MessageCounterBackend.Containers.StatsClasses.DateNameSpace;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.Containers
{
    public class DaysContainer : Container
    {
        public List<Day> Days { get; }
        public List<Day> SortedDays { get; }
        public Day DayWithMaxNumberOfMessages { get; }

        public DaysContainer(JsonStructureClass jsonObject) 
            : this(jsonObject.messages.ToList()) { }
        public DaysContainer(List<MessageJson> messages)
        {
            Days = MakeDaysList(messages);
            SortedDays = SortDaysList(Days);

            if (SortedDays.Count != 0)
                DayWithMaxNumberOfMessages = SortedDays.First();
        }

        private List<Day> MakeDaysList(List<MessageJson> messages)
        {
            // group into single days with their messages
            var grouped = messages.GroupBy(x => new Date(x.timestamp_ms));
            var days = new List<Day>();

            foreach (var d in grouped)
                days.Add(new Day(d.ToList(), d.Key));

            return days;
        }

        private List<Day> SortDaysList(List<Day> days)
            => days.OrderByDescending(x => x.NumberOfMessages).ToList();
    }
}
