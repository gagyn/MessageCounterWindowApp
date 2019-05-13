using MessageCounterBackend;
using MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers;
using System.Windows;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend
{
    internal static class WrapPanelMaker
    {
        public static bool IncludePeople { get; set; }
        public static bool IncludeDays { get; set; }
        public static bool IncludeWords { get; set; }

        public static WrapPanel MakeStatsWrapPanel(StatsContainer statsContainer)
        {
            var panel = new WrapPanel();

            if (statsContainer == null)
                return panel;

            panel.Children.Add(MakeInfoGrid(statsContainer));

            if (IncludePeople)
                panel.Children.Add(
                    new PeopleGridMaker(statsContainer.PeopleContainer).Grid);

            if (IncludeDays)
                panel.Children.Add(
                    new DaysGridMaker(statsContainer.DaysContainer).Grid);

            if (IncludeWords)
                panel.Children.Add(
                    new MessagesGridMaker(statsContainer.WordsContainer).Grid);

            return panel;
        }

        private static Grid MakeInfoGrid(StatsContainer container)
        {
            const int columns = 2;
            var textBlocks = new TextBlock[columns];

            textBlocks[0] = new TextBlock() {
                Text = "Number of all message: \n"
                     + "Number of participants: "
            };

            textBlocks[1] = new TextBlock() {
                Text = container.NumberOfMessages.ToString() + "\n"
                + container.NumberOfParticipants.ToString(),
                FontWeight = FontWeights.SemiBold
            };

            var infoGrid = new Grid()
            {
                Margin = new System.Windows.Thickness(0, 0, 20, 18)
            };

            for (int i = 0; i < columns; i++)
            {
                infoGrid.Children.Add(textBlocks[i]);
                infoGrid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetColumn(infoGrid.Children[i], i);
            }

            return infoGrid;
        }
    }
}
