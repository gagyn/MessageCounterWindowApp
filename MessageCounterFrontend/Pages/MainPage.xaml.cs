using System.Linq;
using MessageCounter;
using MessageCounterFrontend.Pages.StatsPages;
using System.Windows;
using System.Windows.Controls;

namespace MessageCounterFrontend.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : ChoicePage
    {
        public MainPage(StatisticsManager container)
        {
            this.StatsContainer = container;
            InitializeComponent();
        }

        protected override void Buttons_Clicks(object sender, RoutedEventArgs e)
        {
            var page = ((Button) e.Source).Name switch
            {
                nameof(peopleB) => (Page) new PeoplePage(StatsContainer.People),
                nameof(daysB) => new DaysPage(StatsContainer.Days),
                nameof(wordsB) => new WordsPage(StatsContainer.Words.ToList()),
                _ => null
            };

            if (page != null)
                NavigationService.Navigate(page);
        }
    }
}
