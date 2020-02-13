using System.Linq;
using MessageCounter.Models;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class PersonStrings
    {
        public Person Person { get; }
        public PersonStrings(Person person) => this.Person = person;

        public string FullName => Person.Name;
        public int NumberOfMess => Person.Messages.Count();
        public string SentMessesRatio => $"{Person.ConversationMessagesRatio:00.00}%";
        public string SentWordsRatio => $"{Person.ConversationWordsRatio:00.00}%";
       // public string SentUniqueWordsRatio => string.Format("{0:00.00}%", Person.SentUniqueWordsRatio); TODO
        //public double AvgNumberOfMesses => Person.AvgNumberOfMessagesInDaysWhenUserWroteAny;
        //public double AvgNumberOfWords => Person.AvgNumberOfWordsInDaysWhenUserWroteAny;

    }
}
