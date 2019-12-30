using System.Collections.Generic;

namespace MessageCounter.Models
{
    public class Person
    {
        public string Name { get; }
        public IEnumerable<Message> Messages { get; }

        public Person(string name, IEnumerable<Message> messages)
        {
            Name = name;
            Messages = messages;
        }
    }
}
