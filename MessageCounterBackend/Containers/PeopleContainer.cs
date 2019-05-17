using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.JsonStructure;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterBackend.StatContainers
{
    public class PeopleContainer : Container
    {
        public List<Person> People { get; }
        public List<Person> SortedPeople { get; }

        public PeopleContainer(JsonStructureClass jsonObject)
        {
            People = new List<Person>();
            var container = new MessagesContainer(jsonObject);

            foreach (var p in jsonObject.participants)
            {
                var person = new Person(p.name, container);
                this.People.Add(person);
            }

            SortedPeople = People.OrderByDescending(x => x.PersonMessages.NumberOfMessages).ToList();
        }
    }
}
