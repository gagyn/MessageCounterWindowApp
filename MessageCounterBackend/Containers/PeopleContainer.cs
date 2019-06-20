using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.Containers.StatsClasses;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.Containers
{
    public class PeopleContainer : Container
    {
        public List<Person> SortedPeople { get; }

        public PeopleContainer(JsonStructureClass jsonObject)
        {
            List<Person> people = new List<Person>();
            var container = new MessagesContainer(jsonObject);

            foreach (var p in jsonObject.participants)
            {
                var person = new Person(p.name, container);
                people.Add(person);
            }

            SortedPeople = people.OrderByDescending(x => x.PersonMessages.NumberOfMessages).ToList();
        }
    }
}
