using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MessageCounterBackend.Containers.StatsClasses.Date;
using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;
using MessageCounterFrontend.Pages.StatsPages.OneItemPages;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;

namespace MessageCounterFrontend.Pages.StatsPages
{
    /// <summary>
    /// Interaction logic for DaysPage.xaml
    /// </summary>
    public partial class DaysPage : Page
    {
        private DaysContainer Container { get; }
        private ICollectionView LcvDayStrings => new ListCollectionView(GetDaysStrings().ToList());

        public DaysPage(DaysContainer container)
        {
            InitializeComponent();

            this.Container = container;
            this.dataGrid.ItemsSource = LcvDayStrings;
        }

        private IEnumerable<DayStrings> GetDaysStrings()
        {
            var days = this.Container.Days;
            return days.Select(x => new DayStrings(x));
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dayStrings = dataGrid.SelectedItem as DayStrings;
            var day = dayStrings.Day;

            // TODO: 
            //NavigationService.Navigate(new DayPage(day));
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null)
                e.Column.SortDirection = ListSortDirection.Ascending;

            if (e.Column.SortMemberPath == typeof(Date).Name)
            {
                DateSortHandler(sender, e);
                e.Handled = true;
            }
            else // other columns sort in a default way
                e.Handled = false;
        }

        void DateSortHandler(object sender, DataGridSortingEventArgs e)
        {
            ListSortDirection direction = ( e.Column.SortDirection != ListSortDirection.Ascending ) ? ListSortDirection.Ascending : ListSortDirection.Descending;

            e.Column.SortDirection = direction;

            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            lcv.CustomSort = new DayStringsComparer(direction);
        }
    }
}
