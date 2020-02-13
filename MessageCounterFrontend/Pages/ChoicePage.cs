using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MessageCounter;
using MessageCounterFrontend.Pages.StatsPages;

namespace MessageCounterFrontend.Pages
{
    public abstract class ChoicePage : Page
    {
        protected StatisticsManager StatsContainer { get; set; }

        public Page Reload(Page currentContentOfPage)
        {
            this.StatsContainer.ReloadStatistics.Invoke();
            
            switch (currentContentOfPage)
            {
                case PeoplePage _:
                    return new PeoplePage(StatsContainer.People.ToList());
                case DaysPage _:
                    return new DaysPage(StatsContainer.Days);
                case WordsPage _:
                    return new WordsPage(StatsContainer.Words.ToList());
            }
            return null;
        }

        protected abstract void Buttons_Clicks(object sender, RoutedEventArgs e);
    }
}
