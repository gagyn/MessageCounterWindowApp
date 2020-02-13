using System;
using MessageCounter.Models;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class MessageStrings
    {
        public DateTime Date { get; }
        public Person Person { get; }

        public string Message { get; }

        public MessageStrings(Person person, string message, DateTime dateTime)
        {
            this.Date = dateTime;
            this.Person = person;
            this.Message = message;
        }
    }
}
