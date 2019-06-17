using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using MessageCounterBackend.StatContainers;

namespace MessageCounterFrontend.Pages.StatsPages
{
    /// <summary>
    /// Interaction logic for WordsPage.xaml
    /// </summary>
    public partial class WordsPage : Page
    {
        public WordsPage(MessagesContainer container)
        {
            InitializeComponent();
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null)
                e.Column.SortDirection = ListSortDirection.Ascending;
            e.Handled = false;
        }
    }
}
