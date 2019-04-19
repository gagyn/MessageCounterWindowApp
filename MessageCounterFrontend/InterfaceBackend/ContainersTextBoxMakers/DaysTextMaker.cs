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
    static class DaysTextMaker
    {
        public static TextBlock MakeTextBlock(DaysContainer container)
        {
            string content;
            content = "The larger number of messages in single day: "
                + container.dayWithMaxNumberOfMessages.NumberOfMessages;
            content += " on " 
                + container.dayWithMaxNumberOfMessages.thisDateTime.ToShortDateString()
                + "\n";
            content += "Days:\n";

            List<Day> sortedDays = new List<Day>(container.days);
            sortedDays.OrderBy(x => x.NumberOfMessages);

            for (int i = 0; i < container.days.Count; i++)
            {
                Day day = container.days[i];
                content += day.thisDateTime.ToShortDateString();
                content += " ==> " + day.NumberOfMessages + "\t\t\t";
                content += sortedDays[i].thisDateTime.ToShortDateString();
                content += " ==> " + sortedDays[i].NumberOfMessages;
                content += "\n";
            }

            return new TextBlock()
            {
                Text = content
            };
        }
    }
}
