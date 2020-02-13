using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MessageCounter.Models;
using MessageCounterFrontend.Pages.StatsPages.OneItemPages;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages.Comparers;

namespace MessageCounterFrontend.Pages.StatsPages
{
    /// <summary>
    /// Interaction logic for DaysPage.xaml
    /// </summary>
    public partial class DaysPage : Page
    {
        private readonly IEnumerable<Day> _days;
        private ICollectionView LcvDayStrings 
            => new ListCollectionView(GetDaysStrings().ToList());

        public DaysPage(IEnumerable<Day> days)
        {
            this._days = days;
            InitializeComponent();

            this.dataGrid.ItemsSource = LcvDayStrings;
        }

        private IEnumerable<DayStrings> GetDaysStrings()
        {
            return _days.Select(x => new DayStrings(x));
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

            if (e.Column.SortMemberPath == typeof(Day).Name)
            {
                DateSortHandler(sender, e);
                e.Handled = true;
            }
            else // other columns sort in a default way
            {
                e.Handled = false;
            }
        }

        private void DateSortHandler(object sender, DataGridSortingEventArgs e)
        {
            var direction = ( e.Column.SortDirection != ListSortDirection.Ascending ) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            e.Column.SortDirection = direction;

            var lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            lcv.CustomSort = new DayStringsComparer(direction);
        }
    }
}
