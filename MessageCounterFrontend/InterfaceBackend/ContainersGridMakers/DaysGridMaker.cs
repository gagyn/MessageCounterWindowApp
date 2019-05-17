using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers
{
    class DaysGridMaker : GridMaker
    {
        public DaysGridMaker(Container container) : base(container) { }

        protected override Grid[] MakeGrids(Container container)
        {
            if (null == container)
                throw new ArgumentNullException();

            if (!(container is DaysContainer daysContainer))
                throw new ArgumentException();  // if container isn't for days

            Grid[] grids =
            {
                MakeDaysGrid(daysContainer.Days),
                MakeDaysGrid(daysContainer.SortedDays),
                MakeInfoGrid(daysContainer) // the last Grid (InfoGrid) will be in first row
                                            // the rest will be in second row
            };

            return grids;
        }

        protected override Grid MakeBigGrid(Grid[] grids)
        {
            Grid currentGrid = base.MakeBigGrid(grids);

            currentGrid.RowDefinitions.Add(new RowDefinition()); // for info
            currentGrid.RowDefinitions.Add(new RowDefinition()); // for the rest

            int i;
            for (i = 0; i < grids.Length - 1; i++)
                Grid.SetRow(currentGrid.Children[i], 1);

            Grid.SetRow(currentGrid.Children[i], 0);
            Grid.SetColumn(currentGrid.Children[i], 0);
            Grid.SetColumnSpan(currentGrid.Children[i], 2); // merge two columns

            currentGrid.ColumnDefinitions.RemoveAt(currentGrid.ColumnDefinitions.Count - 1);
            return currentGrid;
        }

        private Grid MakeInfoGrid(DaysContainer container) // grid in the first row, first column (0,0)
        {
            string content = "The larger number of messages in single day: ";
            content += container.DayWithMaxNumberOfMessages.NumberOfMessages;
            content += " on ";
            content += container.DayWithMaxNumberOfMessages.ThisDateTime.ToShortDateString();

            var grid = new Grid();
            grid.Children.Add(new TextBlock() { Text = content });
            return grid;
        }

        private Grid MakeDaysGrid(List<Day> days) // second row, first and second column (1,0) && (1,1)
        {
            var grid = new Grid();

            for (int i = 0; i < days.Count; i++)
            {
                TextBlock block = new TextBlock()
                {
                    Text = days[i].ThisDateTime.ToShortDateString()
                    + " ==> " + days[i].NumberOfMessages,
                    Margin = new System.Windows.Thickness(0, 0, 5, 0)
                };

                grid.Children.Add(block);
                grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(grid.Children[i], i);
            }

            return grid;
        }
    }
}
