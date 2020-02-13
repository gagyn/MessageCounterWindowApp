using MessageCounterFrontend.Pages.StatsPages.OneItemPages;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using MessageCounter.Models;

namespace MessageCounterFrontend.Pages.StatsPages
{
    /// <summary>
    /// Interaction logic for PeoplePage.xaml
    /// </summary>
    public partial class PeoplePage : Page
    {
        private readonly IEnumerable<Person> _people;

        public PeoplePage(IEnumerable<Person> people)
        {
            InitializeComponent();

            this._people = people;
            this.dataGrid.ItemsSource = GetPeopleStrings();
        }

        private IEnumerable<PersonStrings> GetPeopleStrings()
        {
            return _people.Select(x => new PersonStrings(x)).ToList();
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var personStrings = dataGrid.SelectedItem as PersonStrings;
            var person = personStrings.Person;

            NavigationService.Navigate(new PersonPage(person));
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null)
                e.Column.SortDirection = ListSortDirection.Ascending;
            e.Handled = false;
        }
    }
}
