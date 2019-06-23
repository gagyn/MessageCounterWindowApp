using MessageCounterBackend;
using MessageCounterFrontend.Pages.StatsPages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MessageCounterFrontend.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : ChoicePage
    {
        public MainPage(StatsContainer container)
        {
            this.StatsContainer = container;
            InitializeComponent();
        }

        protected override void Buttons_Clicks(object sender, RoutedEventArgs e)
        {
            Page page = null;

            switch (( e.Source as Button ).Name)
            {
                case nameof(peopleB):
                    page = new PeoplePage(StatsContainer.PeopleContainer);
                    break;

                case nameof(daysB):
                    page = new DaysPage(StatsContainer.DaysContainer);
                    break;

                case nameof(wordsB):
                    page = new WordsPage(StatsContainer.WordsContainer.SortedWords);
                    break;
            }

            if (page != null)
                NavigationService.Navigate(page);
        }
    }
}
