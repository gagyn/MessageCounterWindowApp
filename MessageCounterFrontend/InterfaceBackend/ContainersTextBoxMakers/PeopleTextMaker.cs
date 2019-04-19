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
            sortedPeople.OrderBy(x => x.NumberOfMessages);

            for (int i = 0; i < sortedPeople.Count; i++)
            {
                Person person = sortedPeople[i];
                content += person.FullName + " ==> ";
                content += person.NumberOfMessages + "\n";
            }

            return new TextBlock()
            {
                Text = content
                Margin = new System.Windows.Thickness(0, 0, 4, 4)
            };
        }
    }
}
