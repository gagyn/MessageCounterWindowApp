using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers
{
    static class PeopleGridMaker
    {
        public static Grid MakeGrid(PeopleContainer container)
        {
            List<Person> sortedPeople = new List<Person>(container.people);
            sortedPeople = sortedPeople.OrderBy(x => x.NumberOfMessages).ToList();
            sortedPeople.Reverse();

            Grid[] grids = {
                MakeLeftSide(sortedPeople),
                MakeCenter(sortedPeople.Count),
                MakeRightSide(sortedPeople)
            };

            Grid bigGrid = new Grid()
            {
                Margin = new Thickness(0, 0, 10, 8),
            };

            for (int i = 0; i < grids.Length; i++)
            {
                bigGrid.ColumnDefinitions.Add(new ColumnDefinition());
                bigGrid.Children.Add(grids[i]);
                Grid.SetColumn(bigGrid.Children[i], i);
            }
            return bigGrid;
        }

        private static Grid MakeLeftSide(List<Person> people)
        {
            Grid grid = new Grid();
            for (int i = 0; i < people.Count; i++)
            {
                grid.Children.Add(new TextBlock()
                {
                    Text = i + ". " + people[i].FullName,
                    HorizontalAlignment = HorizontalAlignment.Left
                });
                grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(grid.Children[i], i);
            }
            return grid;
        }

        private static Grid MakeCenter(int peopleCount)
        {
            Grid grid = new Grid();
            while (peopleCount-- > 0)
            {
                grid.Children.Add(new TextBlock()
                {
                    Text = " ==> ",
                    HorizontalAlignment = HorizontalAlignment.Left
                });
                grid.RowDefinitions.Add(new RowDefinition());
                int i = grid.Children.Count - 1;
                Grid.SetRow(grid.Children[i], i);
            }
            return grid;
        }

        private static Grid MakeRightSide(List<Person> people)
        {
            Grid grid = new Grid();
            foreach (var _ in people)
                grid.RowDefinitions.Add(new RowDefinition());

            foreach (var p in people)
            {
                string ratioString = String.Format("{0:00.00}", p.SentMessagesRatio);

                var block = new TextBlock()
                {
                    Text = $"{p.NumberOfMessages} ({ratioString}%) of this conversation",
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                grid.Children.Add(block);
                int i = grid.Children.Count - 1;
                Grid.SetRow(grid.Children[i], i);
            }

            return grid;
        }
    }
}
