using MessageCounterBackend;
using MessageCounterBackend.StatContainers;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend
{
    internal static class TextBlockMaker
    {
        public static bool IncludePeople { get; set; }
        public static bool IncludeDays { get; set; }
        public static bool IncludeMessages { get; set; }

        public static TextBlock PrepareStatsToString(StatsContainer statsContainer)
        {
            string content;
            content = "Number of all message in this conversation: " + statsContainer.NumberOfMessages.ToString();

            if (IncludeDays)
                content += MakeDaysStatsString(statsContainer.daysContainer);

            var textBlock = new TextBlock()
            {
                Text = content
            };
            return textBlock;
        }

        private static string MakePeopleString(PeopleContainer people)
        {
            string content;


            return content;
        }

        private static string MakeDaysStatsString(DaysContainer days)
        {
            string content;
            content = "The larger number of messages in single day: " + days.dayWithMaxNumberOfMessages.NumberOfMessages;
            content += " on " + days.dayWithMaxNumberOfMessages.thisDateTime.ToShortDateString() + "\n";

            return content;
        }

        private static string MakeMessagesStatsString(MessagesContainer messages)
        {
            string content;


            return content;
        }
    }
}
