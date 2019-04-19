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
        }
    }
}
