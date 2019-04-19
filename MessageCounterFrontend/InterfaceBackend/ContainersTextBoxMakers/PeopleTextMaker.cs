using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers
{
    static class PeopleTextMaker
    {
        public static TextBlock MakeTextBlock(PeopleContainer container)
        {
            string content = "People:\n";

            List<Person> sortedPeople = new List<Person>(container.people);
            sortedPeople.OrderBy(x => x.messages.Count);

            for (int i = 0; i < container.people.Count; i++)
            {
                Person person = container.people[i];
                content += person.fullName + " ==> ";
                content += person.messages.Count + "\n";
            }

            return new TextBlock()
            {
                Text = content
            };
        }
    }
}
