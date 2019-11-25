using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterBackend.Containers.StatsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Message = StringDecoder.DecodeString(message);
        }
    }
}
