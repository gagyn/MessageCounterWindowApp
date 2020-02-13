using System;
using System.Collections.Generic;
using MessageCounter.Models;

namespace MessageCounter
{
    public class StatisticsManager
    {
        public IEnumerable<Day> Days { get; set; }
        public IEnumerable<Person> People { get; set; }
        public IEnumerable<Word> Words { get; set; }

        public Action ReloadStatistics { get; }

        public StatisticsManager(IEnumerable<Day> days, IEnumerable<Person> people, IEnumerable<Word> words, Action<StatisticsManager> reloadAction)
        {
            this.Days = days;
            this.People = people;
            this.Words = words;
            this.ReloadStatistics = () => reloadAction.Invoke(this);
        }
    }
}
