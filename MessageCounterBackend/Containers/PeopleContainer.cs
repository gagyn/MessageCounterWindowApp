using System;
using System.Collections.Generic;
using System.Text;
using MessageCounterBackend.JsonStructure;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterBackend.StatContainers
{
    public class PeopleContainer : Container
    {
        public List<Person> people;

        public PeopleContainer(JsonStructureClass jsonObject)
        {
            people = new List<Person>();
            var container = new MessagesContainer(jsonObject);

            foreach (var p in jsonObject.participants)
            {
                var person = new Person(p.name, container);
                this.people.Add(person);
            }
        }
    }
}
