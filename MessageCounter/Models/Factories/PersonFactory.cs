using MessageCounter.Services.WordsGrouper;
using System.Collections.Generic;
using System.Linq;

namespace MessageCounter.Models.Factories
{
    static class PersonFactory
    {
        public static Person Create(string name, IEnumerable<Message> messagesInConversation)
        {
            var personMessages = messagesInConversation.Where(x => x.AuthorName.Equals(name));
            return new Person(name, personMessages);
        }
    }
}
