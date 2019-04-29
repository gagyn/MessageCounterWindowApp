using MessageCounterBackend;
using MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend
{
    internal static class WrapPanelMaker
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
                + statsContainer.NumberOfMessages + "\n"
                + "Number of participants: "
                + statsContainer.NumberOfParticipants,
                Margin = new System.Windows.Thickness(0, 0, 10, 8)
            };

            panel.Children.Add(toReturn);

            if (IncludePeople)
                panel.Children.Add(
                    new PeopleGridMaker(statsContainer.peopleContainer).Grid);

            if (IncludeDays)
                panel.Children.Add(
                    new DaysGridMaker(statsContainer.daysContainer).Grid);

            if (IncludeMessages)
                panel.Children.Add(
                    new MessagesGridMaker(statsContainer.messagesContainer).Grid);

            return panel;
        }
    }
}
