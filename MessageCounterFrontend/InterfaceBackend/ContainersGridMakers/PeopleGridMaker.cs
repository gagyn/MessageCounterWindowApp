using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers
{
    class PeopleGridMaker : GridMaker
    {
        public PeopleGridMaker(Container container) : base(container)
        {
        }

        protected override Grid[] MakeGrids(Container container)
        {
            if (!(container is PeopleContainer peopleContainer)) 
                throw new ArgumentException();  // if container isn't for people

            List<Person> people = new List<Person>(peopleContainer.people);
            SortPeople(ref people);

            return new Grid[]
            {
                MakeLeftSide(people),
                MakeCenter(people.Count),
                MakeRightSide(people)
            };
        }

        private void SortPeople(ref List<Person> people)
        {
            people = people.OrderBy(x => x.NumberOfMessages).ToList();
            people.Reverse(); // from now, sortedPeople containes people sorted
                                    // by number of messages (top - max number)
        }

        private Grid MakeLeftSide(List<Person> people)
        {
            Grid grid = new Grid();
            for (int i = 0; i < people.Count; i++)
            {
                grid.Children.Add(new TextBlock()
                {
                    Text = (i + 1) + ". " + people[i].FullName, // 1. Name Surname
                    HorizontalAlignment = HorizontalAlignment.Left
                });
                grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(grid.Children[i], i);
            }
            return grid;
        }

        private Grid MakeCenter(int peopleCount)
        {
            Grid grid = new Grid();
            while (peopleCount-- > 0)
            {
                grid.Children.Add(new TextBlock()
                {
                    Text = " ==> ", // ==>
                    HorizontalAlignment = HorizontalAlignment.Left
                });
                grid.RowDefinitions.Add(new RowDefinition());
                int i = grid.Children.Count - 1;
                Grid.SetRow(grid.Children[i], i);
            }
            return grid;
        }

        private Grid MakeRightSide(List<Person> people)
        {
            Grid grid = new Grid();
            foreach (var _ in people)
                grid.RowDefinitions.Add(new RowDefinition());

            foreach (var p in people)
            {
                string ratioString = String.Format("{0:00.00}", p.SentMessagesRatio);

                var block = new TextBlock()
                {
                    Text = $"{p.NumberOfMessages} ({ratioString}%) of this conversation",   // 56% of this conversation
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
