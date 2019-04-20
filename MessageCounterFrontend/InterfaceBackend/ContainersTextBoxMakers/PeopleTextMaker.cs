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
            sortedPeople = sortedPeople.OrderBy(x => x.NumberOfMessages).ToList();
            sortedPeople.Reverse();

            foreach (var p in sortedPeople)
            {
                content += p.FullName + " ==> ";
                content += p.NumberOfMessages + " which equals ";
                content += p.SentMessagesRatio + "% of all messages\n";
            }

            return new TextBlock()
            {
                Text = content,
                Margin = new System.Windows.Thickness(0, 0, 10, 8)
            };
        }
    }
}
