using System.Collections.Generic;

namespace MessageCounter.Models
{
    public class Person
    {
        public string Name { get; }
        public IEnumerable<Message> Messages { get; }
        public IEnumerable<Word> Words { get; }

        public Person(string name, IEnumerable<Message> messages, IEnumerable<Word> words)
        {
            Name = name;
            Messages = messages;
            Words = words;
        }
    }
}
