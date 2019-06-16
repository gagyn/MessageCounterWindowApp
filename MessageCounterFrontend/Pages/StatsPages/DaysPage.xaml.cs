using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using MessageCounterBackend.StatContainers;
using MessageCounterFrontend.Pages.StatsPages.OneItemPages;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;

namespace MessageCounterFrontend.Pages.StatsPages
{
    /// <summary>
    /// Interaction logic for DaysPage.xaml
    /// </summary>
    public partial class DaysPage : Page
    {
        private readonly DaysContainer container;

        public DaysPage(DaysContainer container)
        {
            InitializeComponent();

            this.container = container;
            this.dataGrid.ItemsSource = GetDaysStrings();
        }

        private List<DayStrings> GetDaysStrings()
        {
            var days = this.container.Days;
            return days.Select(x => new DayStrings(x)).ToList();
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dayStrings = dataGrid.SelectedItem as DayStrings;
            var day = dayStrings.Day;

            NavigationService.Navigate(new DayPage(day));
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null)
                e.Column.SortDirection = ListSortDirection.Ascending;
            e.Handled = false;
        }
    }
}
