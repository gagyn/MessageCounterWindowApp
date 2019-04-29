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
        public DaysGridMaker(Container container) : base(container)
        {
        }

        protected override Grid[] MakeGrids(Container container)
        {
            if (!(container is DaysContainer daysContainer))
                throw new ArgumentException();  // if container isn't for days

            Grid[] grids =
            {
                MakeDaysGrid(daysContainer.Days),
                MakeSortedDaysGrid(daysContainer.Days),
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
            return currentGrid;
        }
        private Grid MakeInfoGrid(DaysContainer container)
        {
            string content = "The larger number of messages in single day: ";
            content += container.DayWithMaxNumberOfMessages.NumberOfMessages;
            content += " on ";
            content += container.DayWithMaxNumberOfMessages.thisDateTime.ToShortDateString();

            var grid = new Grid();
            grid.Children.Add(new TextBlock() { Text = content });
            return grid;
        }

        private Grid MakeDaysGrid(List<Day> days)
        {
            var grid = new Grid();

            for (int i = 0; i < days.Count; i++)
            {
                TextBlock block = new TextBlock()
                {
                    Text = days[i].thisDateTime.ToShortDateString()
                    + " ==> " + days[i].NumberOfMessages,
                    Margin = new System.Windows.Thickness(0, 0, 5, 0)
                };

                grid.Children.Add(block);
                grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(grid.Children[i], i);
            }

            return grid;
        }

        private Grid MakeSortedDaysGrid(List<Day> days)
        {
            List<Day> sortedDays = new List<Day>(days);
            sortedDays = sortedDays.OrderBy(x => x.NumberOfMessages).ToList();
            sortedDays.Reverse();

            return MakeDaysGrid(sortedDays);
        }
    }
}
