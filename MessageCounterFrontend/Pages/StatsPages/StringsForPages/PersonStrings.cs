using MessageCounterBackend.Containers.StatsClasses;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class PersonStrings
    {
        public Person Person { get; }
        public PersonStrings(Person person) => this.Person = person;

        public string FullName => Person.FullName;
        public int NumberOfMess => Person.PersonMessages.NumberOfMessages;
        public string SentMessesRatio => string.Format("{0:00.00}%", Person.SentMessagesRatio);
        public string SentWordsRatio => string.Format("{0:00.00}%", Person.SentAllWordsRatio);
        public string SentUniqueWordsRatio => string.Format("{0:00.00}%", Person.SentUniqueWordsRatio);
        public double AvgNumberOfMesses => Person.AvgNumberOfMessagesInDaysWhenUserWroteAny;
        public double AvgNumberOfWords => Person.AvgNumberOfWordsInDaysWhenUserWroteAny;

    }
}
