using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageCounterFrontend.StatsPages.OneItemPages
{
    class PersonStrings
    {
        private Person Person { get; }
        public PersonStrings(Person person) => this.Person = person;

        public string FullName => Person.FullName;
        public double NumberOfMess => Person.PersonMessages.NumberOfMessages;
        public string SentMessesRatio => string.Format("{0:00.00}%", Person.SentMessagesRatio);
        public string SentWordsRatio => string.Format("{0:00.00}%", Person.SentAllWordsRatio);
        public string SentUniqueWordsRatio => string.Format("{0:00.00}%", Person.SentUniqueWordsRatio);
        public double AvgNumberOfMesses => Person.AvgNumberOfMessagesInDaysWhenUserWroteAny;
        public double AvgNumberOfWords => Person.AvgNumberOfWordsInDaysWhenUserWroteAny;

    }
}
