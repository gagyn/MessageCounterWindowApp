using MessageCounterBackend.JsonStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageCounterBackend.StatContainers.ListTypesClasses
{
    public class Person
    {
        public readonly string fullName;
        public readonly List<Message> messages;

        public Person(string fullName, List<Message> messages)
        {
            this.fullName = fullName;
            this.messages = messages;
        }
    }
}
