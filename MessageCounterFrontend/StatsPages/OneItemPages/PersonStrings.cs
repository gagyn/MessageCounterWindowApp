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
        public string NumberOfMess => Person.PersonMessages.NumberOfMessages.ToString();
        public string SentMessesRatio => Person.SentMessagesRatio.ToString() + "%";
        public string SentWordsRatio => Person.SentAllWordsRatio.ToString() + "%";
        public string SentUniqueWordsRatio => Person.SentUniqueWordsRatio.ToString() + "%";
        public string AvgNumberOfMesses => Person.AvgNumberOfMessagesInDaysWhenUserWroteAny.ToString();
        public string AvgNumberOfWords => Person.AvgNumberOfWordsInDaysWhenUserWroteAny.ToString();

    }
}
