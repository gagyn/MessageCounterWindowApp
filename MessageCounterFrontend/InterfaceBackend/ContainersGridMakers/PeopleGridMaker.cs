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
        public PeopleGridMaker(Container container) : base(container) { }

        protected override Grid[] MakeGrids(Container container)
        {
            if (null == container)
                throw new ArgumentNullException();

            if (!(container is PeopleContainer peopleContainer)) 
                throw new ArgumentException();  // if container isn't for people

            List<Person> people = new List<Person>(peopleContainer.SortedPeople);

            return new Grid[]
            {
                MakeLeftSide(people),
                MakeCenter(people.Count),
                MakeRightSide(people),
                MakeMoreRighterSide(people)
            };
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
            
            for (int i = 0; i < peopleCount; i++)
            {
                grid.Children.Add(new TextBlock()
                {
                    Text = " ==> ", // ==>
                    HorizontalAlignment = HorizontalAlignment.Left
                });
                grid.RowDefinitions.Add(new RowDefinition());
                int row = grid.Children.Count - 1;
                Grid.SetRow(grid.Children[row], row);
            }
            return grid;
        }

        private Grid MakeRightSide(List<Person> people)
        {
            Grid grid = new Grid();

            foreach (var p in people)
            {
                string ratioString = String.Format("{0:00.00}", p.SentMessagesRatio);

                var block = new TextBlock()
                {
                    Text = $"{p.PersonMessages.NumberOfMessages} ({ratioString}%)",   // 56% of this conversation
                    HorizontalAlignment = HorizontalAlignment.Right,
                    FontWeight = FontWeights.SemiBold
                };

                grid.Children.Add(block);
                int i = grid.Children.Count - 1;
                grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(grid.Children[i], i);
            }

            return grid;
        }

        private Grid MakeMoreRighterSide(List<Person> people)
        {
            Grid grid = new Grid();

            for (int i = 0; i < people.Count; i++)
            {
                Person p = people[i];
                string ratioString1 = MakeRatioString(p.SentUniqueWordsRatio);
                string ratioString2 = MakeRatioString(p.SentAllWordsRatio);

                string text = p.PersonMessages.NumberOfUniqueWords
                    + " / " + p.PersonMessages.NumberOfAllWords
                    + $" ({ratioString1}% / {ratioString2}%)";

                var block = new TextBlock()
                {
                    Text = text,

                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.SemiBold,
                    Margin = new Thickness(6, 0, 0, 0)
                };

                grid.Children.Add(block);
                grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(grid.Children[i], i);
            }

            return grid;
        }

        private string MakeRatioString(double ratio) => string.Format("{0:00.00}", ratio);
    }
}
