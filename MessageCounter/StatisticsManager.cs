using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageCounter.Models;
using Newtonsoft.Json;

namespace MessageCounter
{
    class StatisticsManager
    {
        public IEnumerable<Day> Days { get; }
        public IEnumerable<Person> People { get; }
        public IEnumerable<Word> Words { get; }

        public StatisticsManager(IEnumerable<Day> days, IEnumerable<Person> people, IEnumerable<Word> words)
        {
            this.Days = days;
            this.People = people;
            this.Words = words;
        }
    }
}
