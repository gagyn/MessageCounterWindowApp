using MessageCounterBackend.Containers;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace MessageCounterFrontend.Pages.StatsPages
{
    /// <summary>
    /// Interaction logic for PeoplePage.xaml
    /// </summary>
    public partial class PeoplePage : Page
    {
        private readonly PeopleContainer container;

        public PeoplePage(PeopleContainer container)
        {
            InitializeComponent();

            this.container = container;
            this.dataGrid.ItemsSource = GetPeopleStrings();
        }

        private List<PersonStrings> GetPeopleStrings()
        {
            var people = this.container.SortedPeople;
            return people.Select(x => new PersonStrings(x)).ToList();
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var personStrings = dataGrid.SelectedItem as PersonStrings;
            var person = personStrings.Person;

            // TODO: 
            //NavigationService.Navigate(new PersonPage(person));
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null)
                e.Column.SortDirection = ListSortDirection.Ascending;
            e.Handled = false;
        }
    }
}
