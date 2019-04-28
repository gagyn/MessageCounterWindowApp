using MessageCounterBackend.StatContainers;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections;
namespace MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers
{
    abstract class GridMaker
    {
        public Grid Grid { get; private set; }

        public GridMaker(Container container)
        {
            var grids = MakeGrids(container);
            Grid = MakeBigGrid(grids);
        }

        protected abstract Grid[] MakeGrids(Container container);
        protected virtual Grid MakeBigGrid(Grid[] grids)
        {
            Grid bigGrid = new Grid()
            {
                Margin = new System.Windows.Thickness(0, 0, 20, 18)
            };

            for (int i = 0; i < grids.Length; i++) // adds every element from grids to big grid
            {
                bigGrid.ColumnDefinitions.Add(new ColumnDefinition());
                bigGrid.Children.Add(grids[i]);
                Grid.SetColumn(bigGrid.Children[i], i);
            }
            return bigGrid;
        }
    }
}
