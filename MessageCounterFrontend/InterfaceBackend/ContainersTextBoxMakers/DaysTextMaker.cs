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
                + container.DayWithMaxNumberOfMessages.NumberOfMessages;
            content += " on " 
                + container.DayWithMaxNumberOfMessages.thisDateTime.ToShortDateString()
                + "\n";
            content += "Days:\n";

            List<Day> sortedDays = new List<Day>(container.Days);
            sortedDays.OrderBy(x => x.NumberOfMessages);

            for (int i = 0; i < container.Days.Count; i++)
            {
                Day day = container.Days[i];
                content += day.thisDateTime.ToShortDateString();
                content += " ==> " + day.NumberOfMessages + "\t\t";
                content += sortedDays[i].thisDateTime.ToShortDateString();
                content += " ==> " + sortedDays[i].NumberOfMessages + "\n";
            }

            return new TextBlock()
            {
                Text = content + "\n",
                Margin = new System.Windows.Thickness(0, 0, 10, 8)
            };
        }
    }
}
