using System.Collections.Generic;
using System.Linq;
using MessageCounter.Services.WordsGrouper;

namespace MessageCounter.Models
{
    public class Person
    {
        public string Name { get; }
        public IEnumerable<Message> Messages { get; }
        public IEnumerable<IGrouping<string, string>> Words { get; }

        public Person(string name, IEnumerable<Message> messages)
        {
            Name = name;
            Messages = messages;
            var wordsGrouper = new WordsGrouperService(messages);
            Words = wordsGrouper.GroupWords();
        }
    }
}
