using System;
using System.Collections.Generic;
using System.Text;
using MessageCounterBackend.JsonStructure;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterBackend.StatContainers
{
    public class PeopleContainer
    {
        public List<Person> people;

        public PeopleContainer(JsonStructureClass jsonObject)
        {
            people = new List<Person>();
            foreach (var p in jsonObject.participants)
            {
                var person = new Person(p.name, (List<Message>)jsonObject.messages);
                this.people.Add(person);
            }
        }
    }
}
