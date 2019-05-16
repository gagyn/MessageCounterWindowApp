using System;
using System.Linq;
using System.Windows.Controls;
using MessageCounterBackend.StatContainers;

namespace MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers
{
    class MessagesGridMaker : GridMaker
    {
        public MessagesGridMaker(Container container) : base(container)
        {
        }

        protected override Grid[] MakeGrids(Container container)
        {
            if (null == container)
                throw new ArgumentNullException();

            if (!(container is MessagesContainer messagesContainer))
                throw new ArgumentException();  // if container isn't for messages

            return new Grid[]
            {
                MakeLeftSide(messagesContainer)
            };
        }

        private Grid MakeLeftSide(MessagesContainer container)
        {
            Grid grid = new Grid();
            for (int i = 0; i < container.SortedWordsByFrequents.Count; i++)
            {
                var word = container.SortedWordsByFrequents[i];

                grid.Children.Add(new TextBlock()
                {
                    Text = word.Count().ToString() + " ==> " + word.Key
                });

                grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(grid.Children[i], i);
            }
            return grid;
        }
    }
}
