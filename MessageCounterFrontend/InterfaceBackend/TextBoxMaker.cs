using MessageCounterBackend;
using MessageCounterBackend.StatContainers;
using MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers;
using System;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend
{
    internal static class TextBlockMaker
    {
        public static bool IncludePeople { get; set; }
        public static bool IncludeDays { get; set; }
        public static bool IncludeMessages { get; set; }

        public static WrapPanel PrepareStatsToString(StatsContainer statsContainer)
        {
            if (statsContainer == null)
                return new WrapPanel();

            WrapPanel panel = new WrapPanel();
            TextBlock toReturn = new TextBlock()
            {
                Text = "Number of all message in this conversation: "
                + statsContainer.NumberOfMessages.ToString() + "\n"
                + "Number of participants: "
                + statsContainer.NumberOfParticipants.ToString() + "\n"
            };

            panel.Children.Add(toReturn);

            if (IncludePeople)
                panel.Children.Add(
                    PeopleTextMaker.MakeTextBlock(statsContainer.peopleContainer));

            if (IncludeDays)
                panel.Children.Add(
                    DaysTextMaker.MakeTextBlock(statsContainer.daysContainer));

            if (IncludeMessages)
                panel.Children.Add(
                    MessagesTextMaker.MakeTextBlock(statsContainer.messagesContainer));

            return panel;
        }

        private static string MakePeopleString(PeopleContainer people)
        {
            string content = null;


            return content;
        }

        private static string MakeDaysStatsString(DaysContainer days)
        {
            string content;
            content = "The larger number of messages in single day: " + days.DayWithMaxNumberOfMessages.NumberOfMessages;
            content += " on " + days.DayWithMaxNumberOfMessages.thisDateTime.ToShortDateString() + "\n";
            content += "Days:";
            return content;
        }

        private static string MakeMessagesStatsString(MessagesContainer messages)
        {
            string content = null;


            return content;
        }
    }
}
