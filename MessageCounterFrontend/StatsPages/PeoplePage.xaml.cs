using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;
using MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers;
using MessageCounterFrontend.StatsPages.OneItemPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageCounterFrontend.StatsPage
{
    /// <summary>
    /// Interaction logic for PeoplePage.xaml
    /// </summary>
    public partial class PeoplePage : Page
    {
        private List<PersonStrings> PeopleStrings { get; }
        public PeoplePage(PeopleContainer container)
        {
            var people = container.SortedPeople;
            PeopleStrings = people.Select(x => new PersonStrings(x)).ToList();

            InitializeComponent();

            this.dataGrid.ItemsSource = PeopleStrings;
        }
    }
}
