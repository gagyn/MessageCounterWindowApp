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
    public partial class MainPage : Page
    {
        private StatsContainer StatsContainer { get; set; }
        private WrapPanel MainWrapPanel
        {
            get => scrollViewer.Content as WrapPanel;
            set => scrollViewer.Content = value;
        }

        public MainPage(StatsContainer container)
        {
            this.StatsContainer = container;
            InitializeComponent();
        }

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
                    return new WordsPage(StatsContainer.WordsContainer);
            }
            return null;
        }

        private void Buttons_Clicks(object sender, RoutedEventArgs e)
        {
            switch ((e.Source as Button).Name)
            {
                case nameof(peopleB):
                    MakePeopleContainerIfNeeded();
                    NavigationService.Navigate(new PeoplePage(StatsContainer.PeopleContainer));
                    break;

                case nameof(daysB):
                    MakeDaysContainerIfNeeded();
                    NavigationService.Navigate(new DaysPage(StatsContainer.DaysContainer));
                    break;

                case nameof(WordsB):
                    MakeWordsContainerIfNeeded();
                    NavigationService.Navigate(new WordsPage(StatsContainer.WordsContainer));
                    break;
            }
        }

        private void MakePeopleContainerIfNeeded()
        {
            if (null == StatsContainer.PeopleContainer)
                StatsContainer.MakePeopleContainer();
        }

        private void MakeDaysContainerIfNeeded()
        {
            if (null == StatsContainer.DaysContainer)
                StatsContainer.MakeDaysContainer();
        }

        private void MakeWordsContainerIfNeeded()
        {
            if (null == StatsContainer.WordsContainer)
                StatsContainer.MakeWordsContainer();
        }
    }
}
