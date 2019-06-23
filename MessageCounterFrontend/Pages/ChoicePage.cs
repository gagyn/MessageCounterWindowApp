using System.Windows;
using System.Windows.Controls;
using MessageCounterBackend;
using MessageCounterFrontend.Pages.StatsPages;

namespace MessageCounterFrontend.Pages
{
    public abstract class ChoicePage : Page
    {
        protected StatsContainer StatsContainer { get; set; }

        public Page Reload(Page currentContentOfPage)
        {
            this.StatsContainer.ReloadContainers();
            
            switch (currentContentOfPage)
            {
                case PeoplePage _:
                    return new PeoplePage(StatsContainer.PeopleContainer);
                case DaysPage _:
                    return new DaysPage(StatsContainer.DaysContainer);
                case WordsPage _:
                    return new WordsPage(StatsContainer.WordsContainer.SortedWords);
            }
            return null;
        }

        protected abstract void Buttons_Clicks(object sender, RoutedEventArgs e);
    }
}
